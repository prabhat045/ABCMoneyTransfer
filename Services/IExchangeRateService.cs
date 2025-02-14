namespace ABCMoneyTransfer.Services
{
    public interface IExchangeRateService
    {
        Task<decimal> GetExchangeRateAsync();
    }
}
