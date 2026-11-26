namespace AtmManagement.DTO
{
    public class ReconciliationLogDTO
    {
        public string SessionId { get; set; } = string.Empty;
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public int TotalTransactions { get; set; }
        public int MatchedCount { get; set; }
        public int DiscrepancyCount { get; set; }
        public string Status { get; set; } = string.Empty;
        public string OperatorName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    public class ReconciliationProgressDTO
    {
        public int PercentComplete { get; set; }
        public int ProcessedTransactions { get; set; }
        public int TotalTransactions { get; set; }
        public int DiscrepanciesFound { get; set; }
        public string CurrentStep { get; set; } = string.Empty;
    }
}
