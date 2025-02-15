using ABCMoneyTransfer.DTOs;

namespace ABCMoneyTransfer.Services
{
    public interface ITransactionService
    {
        public Task ProcessTransferAsync(string userId, TransferRequestDTO model);

        public Task<List<TransactionDTO>> GenerateReportAsync(string userId, TransactionReportFilterDTO filter);

    }
}
