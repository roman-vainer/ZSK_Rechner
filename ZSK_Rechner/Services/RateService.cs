using ZSK_Rechner.ViewModels;
using ZSK_Rechner.Models;

namespace ZSK_Rechner.Services
{
    public class RateService
    {
        public List<RateHistoryViewModel> GetRates(List<ExchangeRate> rates)
        {
            decimal? previousRate = null;
            List<RateHistoryViewModel> rateHistory = new();
            foreach (var rate in rates)
            {
                rateHistory.Add(new RateHistoryViewModel
                {
                    Rate = rate.Rate,
                    ValidFrom = rate.ValidFrom,
                    PreviousRate = previousRate,
                    ChangeRate = previousRate.HasValue ? (rate.Rate - previousRate.Value) / previousRate.Value * 100 : 0
                });
                previousRate = rate.Rate;
            }
            return rateHistory.OrderByDescending(r => r.ValidFrom).ToList();
        }
    }
}
