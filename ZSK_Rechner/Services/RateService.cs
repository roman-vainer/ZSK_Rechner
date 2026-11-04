using ZSK_Rechner.ViewModels;
using ZSK_Rechner.Models;

namespace ZSK_Rechner.Services
{
    public class RateService
    {
        public List<RateHistoryViewModel> GerRates(List<ExchangeRate> rates)
        {
            decimal? PreviousRate = null;
            List<RateHistoryViewModel> rateHistory = new();
            foreach (var rate in rates)
            {
                rateHistory.Add(new RateHistoryViewModel
                {
                    Rate = rate.Rate,
                    ValidFrom = rate.ValidFrom,
                    PreviousRate = PreviousRate,
                    ChangeRate = PreviousRate.HasValue ? rate.Rate - PreviousRate.Value : null
                });
                PreviousRate = rate.Rate;
            }
            return rateHistory;
        }
    }
}
