using PowerGridScada.DAL;
using PowerGridScada.DTO;

namespace PowerGridScada.BUS
{
    public class ScadaMonitorBUS
    {
        public const double OverloadThresholdPercent = 85.0;

        private readonly SubstationDAL _substationDal = new();
        private readonly GridLogDAL _gridLogDal = new();

        public List<SubstationDTO> GetSubstations() => _substationDal.GetAll();

        public List<GridIncidentLogDTO> GetIncidentLogs() => _gridLogDal.GetAll();

        public void ClearIncidentLogs() => _gridLogDal.Clear();

        /// <summary>
        /// Sinh ngẫu nhiên thông số vận hành SCADA theo đúng dải quy định:
        /// Điện áp: 108 kV - 115 kV; Mức mang tải: 50% - 98%.
        /// Nếu vượt ngưỡng > 85% thì ghi nhận vào nhật ký sự cố quá tải.
        /// </summary>
        public (TelemetryReadingDTO Reading, GridIncidentLogDTO? Incident) SampleTelemetry(
            SubstationDTO substation,
            int cycleNumber,
            Random random)
        {
            double voltageKv = Math.Round(108.0 + random.NextDouble() * 7.0, 2); // 108.00 - 115.00 kV
            double loadPercent = Math.Round(50.0 + random.NextDouble() * 48.0, 1); // 50.0% - 98.0%
            bool isOverloaded = loadPercent > OverloadThresholdPercent;
            var now = DateTime.Now;

            var reading = new TelemetryReadingDTO
            {
                SubstationCode = substation.SubstationCode,
                SubstationName = substation.SubstationName,
                VoltageKv = voltageKv,
                LoadPercent = loadPercent,
                Timestamp = now,
                CycleNumber = cycleNumber,
                IsOverloaded = isOverloaded
            };

            GridIncidentLogDTO? incident = null;
            if (isOverloaded)
            {
                string severity = loadPercent >= 93.0 ? "NGUY HIỂM (Khẩn cấp)" : "CẢNH BÁO QUÁ TẢI";
                incident = _gridLogDal.AddIncident(new GridIncidentLogDTO
                {
                    RecordedAt = now,
                    SubstationCode = substation.SubstationCode,
                    SubstationName = substation.SubstationName,
                    VoltageKv = voltageKv,
                    LoadPercent = loadPercent,
                    Severity = severity,
                    Message = $"Mức mang tải {loadPercent:F1}% vượt ngưỡng an toàn ({OverloadThresholdPercent:F0}%)."
                });
            }

            return (reading, incident);
        }
    }
}
