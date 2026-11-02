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
            var animals = _context.Animals
                .Select(a => new AnimalViewModel
                {
                    Name = a.Name,
                    Rate = _context.ExchangeRates
                    .Where(e => e.AnimalId == a.Id)
                    .OrderByDescending(e => e.ValidFrom)
                    .ThenByDescending(e => e.Id)
                    .Select(e => e.Rate)
                    .FirstOrDefault()
                }).ToList();
         
            return View(animals);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(new AnimalViewModel());
        }

        [HttpPost]
        public IActionResult Create(AnimalViewModel model)
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

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var animal = _context.ExchangeRates
                .Where(e => e.Id == id)
                .Select(e => new AnimalViewModel
                {
                    Name = e.Animal.Name,
                    Rate = e.Rate
                }).FirstOrDefault();

            return View(animal);
        }

        [HttpPost]
        public IActionResult Edit(AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var animal = _context.Animals.Find(model.)

            _context.ExchangeRates.Add(new ExchangeRate
            {
                Animal = _context.Animals.FirstOrDefault(a => a.Name == model.Name)!,
                Rate = model.Rate,
                ValidFrom = DateTime.UtcNow
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}