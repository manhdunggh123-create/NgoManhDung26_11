namespace PowerGridScada.DTO
{
    public class SubstationDTO
    {
        public string SubstationCode { get; set; } = string.Empty;
        public string SubstationName { get; set; } = string.Empty;
        public double NominalVoltageKv { get; set; } = 110.0;
        public double SafeLoadThresholdPercent { get; set; } = 85.0;
        public string Region { get; set; } = string.Empty;

        public override string ToString() => $"{SubstationName} ({SubstationCode})";
    }

    public class TelemetryReadingDTO
    {
        public string SubstationCode { get; set; } = string.Empty;
        public string SubstationName { get; set; } = string.Empty;
        public double VoltageKv { get; set; }
        public double LoadPercent { get; set; }
        public DateTime Timestamp { get; set; }
        public int CycleNumber { get; set; }
        public bool IsOverloaded { get; set; }
    }

    public class GridIncidentLogDTO
    {
        public int LogId { get; set; }
        public DateTime RecordedAt { get; set; }
        public string SubstationCode { get; set; } = string.Empty;
        public string SubstationName { get; set; } = string.Empty;
        public double VoltageKv { get; set; }
        public double LoadPercent { get; set; }
        public string Severity { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
