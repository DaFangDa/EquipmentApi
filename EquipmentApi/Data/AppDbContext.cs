using Microsoft.EntityFrameworkCore;
using EquipmentApi.Models;

namespace EquipmentApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Equipment> Equipments { get; set; }
    }
}
