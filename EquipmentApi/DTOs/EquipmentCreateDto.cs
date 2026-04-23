using System.ComponentModel.DataAnnotations;

namespace EquipmentApi.DTOs
{
    // 新增資料用DTO
    public class EquipmentCreateDto
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
    }
}
