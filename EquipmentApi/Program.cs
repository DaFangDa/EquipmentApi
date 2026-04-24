using EquipmentApi.Data;
using EquipmentApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EquipmentApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("EquipmentDb"));
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // 全域例外處理
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var exceptionHandlerPathFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
                    var ex = exceptionHandlerPathFeature?.Error;
                    var result = new { error = "伺服器發生錯誤", message = ex?.Message };
                    await context.Response.WriteAsJsonAsync(result);
                });
            });

            app.MapControllers();

            // 種子資料
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Equipments.Any())
                {
                    context.Equipments.Add(new Equipment { Name = "蝕刻機", Company = "應材", Area = "A區", InstallationDate = new DateTime(2024, 5, 20) });
                    context.SaveChanges();
                }
            }

            app.Run();
        }
    }
}
