using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using ZSK_Rechner.Models;
using ZSK_Rechner.Services;
using ZSK_Rechner.ViewModels;
namespace ZSK_Rechner.Controllers;

public class CalculateController : Controller
{
    private ZSKDBContext _context;
    private CalculateService service = new CalculateService();

    public CalculateController(ZSKDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        CalculateViewModel model = new CalculateViewModel
        {
            Animals = _context.Animals.ToList()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Calculate(CalculateViewModel model)
    {
        
        var animals = _context.Animals.ToList();
        model.Animals = animals;
        model.AnimalName = animals.FirstOrDefault(a => a.Id == model.AnimalId)?.Name;
        var rate = _context.ExchangeRates
            .Where(e => e.AnimalId == model.AnimalId)
            .OrderByDescending(e => e.ValidFrom)
            .ThenByDescending(e => e.Id)
            .Select(e => e.Rate)
            .FirstOrDefault();
        model.AppliedRate = rate;


        model.Result = service.Convert(model.Value ?? 0, rate, model.Direction);
        return View("Index", model);
    }
}
