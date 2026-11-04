using Microsoft.AspNetCore.Mvc;
using ZSK_Rechner.Models;
using ZSK_Rechner.Services;
using ZSK_Rechner.ViewModels;
namespace ZSK_Rechner.Controllers
{
    public class ExchangeRateController : Controller
    {
        private ZSKDBContext _context;

        public ExchangeRateController(ZSKDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<RateViewModel> rateViewModels = new();
            var animals = _context.Animals.ToList();
            RateService rateService = new RateService();
            List<ExchangeRate> rates = new();

            foreach (var animal in animals)
            {
                rates = _context.ExchangeRates
                    .Where(e => e.AnimalId == animal.Id)
                    .OrderBy(e=>e.ValidFrom)
                    .ToList();

                List<RateHistoryViewModel> rateHistory = rateService.GetRates(rates);

                var rateViewModel = new RateViewModel
                {
                    AnimalId = animal.Id,
                    AnimalName = animal.Name,
                    RateHistory = rateHistory
                };
                rateViewModels.Add(rateViewModel);
            }
            return View(rateViewModels);
        }
    }
}
