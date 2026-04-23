using EquipmentApi.Data;
using EquipmentApi.DTOs;
using EquipmentApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EquipmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EquipmentController(AppDbContext context)
        {
            _context = context;
        }

        // 搜尋資料
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<EquipmentResponseDto>>> Search([FromQuery] string? keyword, [FromQuery] DateTime? start_time, [FromQuery] DateTime? end_time)
        {
            try
            {
                var query = _context.Equipments.AsNoTracking();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    keyword = keyword.Trim();
                    query = query.Where(q => q.Name.Contains(keyword) ||
                    q.Company.Contains(keyword) ||
                    q.Area.Contains(keyword));
                }
                if (start_time.HasValue)
                {
                    query = query.Where(q => q.InstallationDate >= start_time.Value);
                }
                if (end_time.HasValue)
                {
                    query = query.Where(q => q.InstallationDate <= end_time.Value);
                }
                var result = await query.OrderBy(q => q.Id)
                .Select(q => new EquipmentResponseDto
                {
                    Id = q.Id,
                    Name = q.Name,
                    Company = q.Company,
                    Area = q.Area,
                    InstallationDate = q.InstallationDate,
                    LastMaintenanceDate = q.LastMaintenanceDate,
                    UnderMaintenance = q.UnderMaintenance,
                    ReasonForMaintenance = q.ReasonForMaintenance,
                    CreatedAt = q.CreatedAt,
                    UpdateAt = q.UpdateAt
                })
                .ToListAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, $"搜尋資料時發生錯誤");
            }
        }

        // 獲取指定資料
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipmentResponseDto>> GetID([FromRoute] int id)
        {
            try
            {
                var result = await _context.Equipments.Where(e => e.Id == id)
                .Select(e => new EquipmentResponseDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Company = e.Company,
                    Area = e.Area,
                    InstallationDate = e.InstallationDate,
                    LastMaintenanceDate = e.LastMaintenanceDate,
                    UnderMaintenance = e.UnderMaintenance,
                    ReasonForMaintenance = e.ReasonForMaintenance,
                    CreatedAt = e.CreatedAt,
                    UpdateAt = e.UpdateAt
                })
                .FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound($"找不到ID為 {id} 的資料");
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, $"獲取指定資料時發生錯誤");
            }
        }

        // 新增資料
        [HttpPost]
        public async Task<ActionResult<EquipmentResponseDto>> Add([FromBody] EquipmentCreateDto create)
        {
            if (create == null)
            {
                return BadRequest("資料內容不可為空");
            }
            try
            {
                var new_equipment = new Equipment
                {
                    Name = create.Name.Trim(),
                    Company = create.Company.Trim(),
                    Area = create.Area.Trim(),
                    InstallationDate = create.InstallationDate
                };
                _context.Equipments.Add(new_equipment);
                await _context.SaveChangesAsync();
                var response = new EquipmentResponseDto
                {
                    Id = new_equipment.Id,
                    Name = new_equipment.Name,
                    Company = new_equipment.Company,
                    Area = new_equipment.Area,
                    InstallationDate = new_equipment.InstallationDate,
                    LastMaintenanceDate = new_equipment.LastMaintenanceDate,
                    UnderMaintenance = new_equipment.UnderMaintenance,
                    ReasonForMaintenance = new_equipment.ReasonForMaintenance,
                    CreatedAt = new_equipment.CreatedAt,
                    UpdateAt = new_equipment.UpdateAt
                };
                return CreatedAtAction(nameof(GetID), new { id = new_equipment.Id }, response);
            }
            catch (Exception)
            {
                return StatusCode(500, $"新增資料時發生錯誤");
            }
        }

        // 更新資料
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] EquipmentUpdateDto update)
        {
            if (update == null)
            {
                return BadRequest("更新內容不可為空");
            }
            try
            {
                var equipment = await _context.Equipments.FindAsync(id);
                if (equipment == null)
                {
                    return NotFound($"找不到ID為 {id} 的資料");
                }
                equipment.Name = update.Name.Trim();
                equipment.Company = update.Company.Trim();
                equipment.Area = update.Area.Trim();
                equipment.InstallationDate = update.InstallationDate;
                equipment.LastMaintenanceDate = update.LastMaintenanceDate;
                equipment.UnderMaintenance = update.UnderMaintenance;
                equipment.ReasonForMaintenance = update.ReasonForMaintenance?.Trim();
                equipment.UpdateAt = DateTime.Now;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("資料在更新過程中已被其他使用者修改，請重新整理後再試");
            }
            catch (Exception)
            {
                return StatusCode(500, $"更新資料時發生錯誤");
            }
        }

        // 刪除資料
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var equipment = await _context.Equipments.FindAsync(id);
                if (equipment == null)
                {
                    return NotFound($"找不到ID為 {id} 的資料");
                }
                _context.Equipments.Remove(equipment);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, $"刪除資料時發生錯誤");
            }
        }
    }
}
