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
                    AnimalId = a.Id,
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
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            var model = new AnimalViewModel
            {
                AnimalId = animal.Id,
                Name = animal.Name,
                Rate = _context.ExchangeRates
                .Where(e => e.AnimalId == animal.Id)
                .OrderByDescending(e => e.ValidFrom)
                .ThenByDescending(e => e.Id)
                .Select(e => e.Rate)
                .FirstOrDefault()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var animal = _context.Animals.Find(model.AnimalId);
            if (animal == null)
            {
                return NotFound();
            }
            if (model.Name != animal.Name)
            {
                animal.Name = model.Name;
            }

            _context.ExchangeRates.Add(new ExchangeRate
            {
                AnimalId = model.AnimalId,
                Rate = model.Rate,
                ValidFrom = DateTime.UtcNow
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null)
            {
                return NotFound();
            }
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}