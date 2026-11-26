using AtmManagement.DAL;
using AtmManagement.DTO;

namespace AtmManagement.BUS
{
    public class ReconciliationBUS
    {
        private readonly ReconciliationDAL _dal = new();

        public List<ReconciliationLogDTO> GetHistory()
        {
            return _dal.GetAll();
        }

        /// <summary>
        /// Thực hiện đối soát sao kê giao dịch ATM bất đồng bộ bằng Task.Run kết hợp Task.Delay
        /// (mô phỏng 4 - 6 giây đối chiếu hàng trăm nghìn giao dịch mà không khóa UI Thread).
        /// </summary>
        public async Task<ReconciliationLogDTO> RunAutoReconciliationAsync(
            string operatorName,
            IProgress<ReconciliationProgressDTO>? progress,
            CancellationToken cancellationToken)
        {
            var startedAt = DateTime.Now;
            var sessionId = $"REC-{startedAt:yyyyMMdd-HHmmss}";

            return await Task.Run(async () =>
            {
                var random = new Random();
                int totalTransactions = random.Next(180_000, 260_000);
                int totalSteps = 100;
                int delayPerStepMs = random.Next(45, 58); // ~4.5s - 5.8s
                int discrepancies = 0;
                int processed = 0;

                try
                {
                    for (int step = 1; step <= totalSteps; step++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        await Task.Delay(delayPerStepMs, cancellationToken).ConfigureAwait(false);

                        processed = (int)((long)totalTransactions * step / totalSteps);

                        // Giả lập phát hiện một số ít giao dịch lệch sao kê
                        if (step % 17 == 0 && random.Next(0, 100) < 65)
                        {
                            discrepancies += random.Next(1, 3);
                        }

                        string stepDesc = step switch
                        {
                            <= 20 => "Đang tải tệp sao kê giao dịch rút tiền/chuyển khoản từ Core Banking...",
                            <= 45 => "Đang giải mã & chuẩn hóa dữ liệu nhật ký máy ATM (Journal)...",
                            <= 80 => "Đang đối chiếu chéo số tiền, mã thẻ và mã chuẩn chi (Auth Code)...",
                            <= 95 => "Đang phân loại giao dịch sai lệch và lập danh sách tra soát...",
                            _ => "Đang tổng hợp báo cáo đối soát cuối ngày..."
                        };

                        progress?.Report(new ReconciliationProgressDTO
                        {
                            PercentComplete = step,
                            ProcessedTransactions = processed,
                            TotalTransactions = totalTransactions,
                            DiscrepanciesFound = discrepancies,
                            CurrentStep = stepDesc
                        });
                    }

                    var completedLog = new ReconciliationLogDTO
                    {
                        SessionId = sessionId,
                        StartedAt = startedAt,
                        CompletedAt = DateTime.Now,
                        TotalTransactions = totalTransactions,
                        MatchedCount = totalTransactions - discrepancies,
                        DiscrepancyCount = discrepancies,
                        Status = "Hoàn tất",
                        OperatorName = operatorName,
                        Notes = discrepancies == 0
                            ? "100% giao dịch khớp hoàn toàn với Core Banking."
                            : $"Phát hiện {discrepancies} giao dịch lệch, đã tự động chuyển bộ phận tra soát."
                    };

                    _dal.AddLog(completedLog);
                    return completedLog;
                }
                catch (OperationCanceledException)
                {
                    var cancelledLog = new ReconciliationLogDTO
                    {
                        SessionId = sessionId,
                        StartedAt = startedAt,
                        CompletedAt = DateTime.Now,
                        TotalTransactions = processed,
                        MatchedCount = Math.Max(0, processed - discrepancies),
                        DiscrepancyCount = discrepancies,
                        Status = "Đã dừng bởi người dùng",
                        OperatorName = operatorName,
                        Notes = $"Tiến trình bị hủy tại mức {processed:N0}/{totalTransactions:N0} giao dịch."
                    };

                    _dal.AddLog(cancelledLog);
                    throw;
                }
            }, CancellationToken.None);
        }
    }
}
