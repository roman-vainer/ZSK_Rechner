using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ZSK_Rechner.ViewModels
{
    public class AnimalViewModel
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string AnimalName { get; set; } = string.Empty;

        [Range(0.01, 1000000, ErrorMessage = "Rate must be between 0.01 and 1000000")]
        [Precision(18, 2)]
        public decimal? Rate { get; set; }
    }
}
