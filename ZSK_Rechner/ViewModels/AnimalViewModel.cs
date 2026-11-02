using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZSK_Rechner.ViewModels
{
    public class AnimalViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "Rate must be between 0.01 and 1000000")]
        [Precision(18, 2)]
        public decimal Rate { get; set; }
    }
}
