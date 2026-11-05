using ZSK_Rechner.ViewModels;
using ZSK_Rechner.Models;

namespace ZSK_Rechner.Services
{
    public class RateService
    {
        public List<RateHistoryViewModel> GetRates(List<ExchangeRate> rates)
        {
            decimal? previousRate = null;
            List<RateHistoryViewModel> history = new();
            foreach (var rate in rates)
            {
                history.Add(new RateHistoryViewModel
                {
                    Rate = rate.Rate,
                    ValidFrom = rate.ValidFrom,
                    PreviousRate = previousRate,
                    ChangeRate = previousRate > 0 ? (rate.Rate - previousRate.Value) / previousRate.Value * 100m : null
                });
                previousRate = rate.Rate;
            }
            history.Reverse();
            return history;
        }
    }
}
