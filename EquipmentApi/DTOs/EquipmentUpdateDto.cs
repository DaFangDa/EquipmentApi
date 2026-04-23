using System.ComponentModel.DataAnnotations;

namespace EquipmentApi.DTOs
{
    // 更新資料用DTO
    public class EquipmentUpdateDto
    {
        [Required]
        [RegularExpression(@"^(?!\s*$).+")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(?!\s*$).+")]
        public string Company { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(?!\s*$).+")]
        public string Area { get; set; } = string.Empty;

        [Required]
        public DateTime InstallationDate { get; set; }

        public DateTime? LastMaintenanceDate { get; set; } = null;

        public bool UnderMaintenance { get; set; } = false;

        [RegularExpression(@"^(?!\s*$).+")]
        [StringLength(100)]
        public string? ReasonForMaintenance { get; set; } = null;
    }
}
