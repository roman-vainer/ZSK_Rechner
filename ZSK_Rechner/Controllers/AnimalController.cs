using Microsoft.AspNetCore.Mvc;
using ZSK_Rechner.Models;
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
            return View();
        }
    }
}
