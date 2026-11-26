namespace AtmManagement.DTO
{
    public class AtmStationDTO
    {
        public string StationCode { get; set; } = string.Empty;
        public string LocationAddress { get; set; } = string.Empty;
        public decimal CashBalance { get; set; }
        public string Status { get; set; } = "Hoạt động";
        public string? PhotoPath { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.Now;
    }
}
