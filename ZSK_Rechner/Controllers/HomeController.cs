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
            decimal cowRate = _context.ExchangeRates.Where(r => r.Animal.Name == "Kuh")
                .OrderByDescending(r => r.ValidFrom)
                .ThenByDescending(r => r.Id)
                .Select(r => r.Rate)
                .FirstOrDefault();

            var model = new HomeViewModel
            {
                CowRate = cowRate
            };
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
