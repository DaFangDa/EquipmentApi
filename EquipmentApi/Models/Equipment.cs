using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EquipmentApi.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Company {  get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public DateTime InstallationDate { get; set; }
        public DateTime? LastMaintenanceDate { get; set; } = null;
        public bool UnderMaintenance { get; set; } = false;
        public string? ReasonForMaintenance { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
    }
}
