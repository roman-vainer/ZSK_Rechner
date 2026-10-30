using Microsoft.AspNetCore.Mvc;
using ZSK_Rechner.Models;
namespace ZSK_Rechner.Controllers
{
    public class CalculateController : Controller
    {
        private ZSKDBContext _context;

        public CalculateController(ZSKDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
