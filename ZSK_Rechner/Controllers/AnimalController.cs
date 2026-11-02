using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZSK_Rechner.Models;
using ZSK_Rechner.ViewModels;
namespace ZSK_Rechner.Controllers
{
    public class AnimalController : Controller
    {
        private ZSKDBContext _context;

        public AnimalController(ZSKDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var animals = _context.ExchangeRates
                .GroupBy(e => e.AnimalId)
                .Select(g => g.OrderByDescending(d => d.ValidFrom).First())
                .Select(e => new AnimalCreateViewModel
                {
                    Name = e.Animal.Name,
                    Rate = e.Rate
                }).ToList();
            return View(animals);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new AnimalCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(AnimalCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Animal animal = new(model.Name);
            ExchangeRate exchangeRate = new()
            {
                Animal = animal,
                Rate = model.Rate,
                ValidFrom = DateTime.UtcNow
            };

            _context.Animals.Add(animal);
            _context.ExchangeRates.Add(exchangeRate);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}