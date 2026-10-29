
using System.ComponentModel.DataAnnotations;

namespace ZSK_Rechner.Models
{
    public class Animal (string name)
    {
        public int Id { get; private set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = name;

    }
}
