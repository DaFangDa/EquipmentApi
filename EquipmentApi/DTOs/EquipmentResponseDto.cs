namespace EquipmentApi.DTOs
{
    // 回傳資料用DTO
    public class EquipmentResponseDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Company { get; init; } = string.Empty;
        public string Area { get; init; } = string.Empty;
        public DateTime InstallationDate { get; init; }
        public DateTime? LastMaintenanceDate { get; init; }
        public bool UnderMaintenance { get; init; }
        public string? ReasonForMaintenance { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdateAt { get; init; }
    }
}
