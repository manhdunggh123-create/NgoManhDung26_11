using AtmManagement.DTO;

namespace AtmManagement.DAL
{
    public class ReconciliationDAL
    {
        private static readonly object SyncRoot = new();
        private static readonly List<ReconciliationLogDTO> Logs = new()
        {
            new ReconciliationLogDTO
            {
                SessionId = "REC-20261125-01",
                StartedAt = DateTime.Now.AddDays(-1).Date.AddHours(17).AddMinutes(30),
                CompletedAt = DateTime.Now.AddDays(-1).Date.AddHours(17).AddMinutes(30).AddSeconds(5),
                TotalTransactions = 184_520,
                MatchedCount = 184_516,
                DiscrepancyCount = 4,
                Status = "Hoàn tất",
                OperatorName = "Đỗ Việt Hoàng",
                Notes = "Đã tự động tạo phiếu tra soát cho 4 giao dịch lệch."
            }
        };

        public List<ReconciliationLogDTO> GetAll()
        {
            lock (SyncRoot)
            {
                return Logs
                    .OrderByDescending(l => l.StartedAt)
                    .ToList();
            }
        }

        public void AddLog(ReconciliationLogDTO log)
        {
            lock (SyncRoot)
            {
                Logs.Insert(0, log);
            }
        }
    }
}
