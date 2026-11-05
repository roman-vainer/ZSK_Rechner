using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZSK_Rechner.Models;
using ZSK_Rechner.ViewModels;

namespace ZSK_Rechner.Controllers
{
    public class HomeController : Controller
    {
        private ZSKDBContext _context;

        public HomeController(ZSKDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var animal = _context.Animals.FirstOrDefault();
            var model = new HomeViewModel
            {
                Name = animal?.Name ?? string.Empty
            };

                if (animal != null)
            {
                model.Rate = _context.ExchangeRates
                    .Where(e => e.AnimalId == animal.Id)
                    .OrderByDescending(e => e.ValidFrom)
                    .ThenByDescending(e => e.Id)
                    .Select(e => e.Rate)
                    .FirstOrDefault();
            }

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
