using ZSK_Rechner.Enums;
using ZSK_Rechner.Models;
namespace ZSK_Rechner.ViewModels;

using System.ComponentModel.DataAnnotations;

public class CalculateViewModel
{
    public ConvertionDirection Direction { get; set; }
    [Required(ErrorMessage = "Bitte Tierart auswählen.")]
    public int? AnimalId { get; set; }
    public string? AnimalName { get; set; }
    [Required(ErrorMessage = "Bitte Wert eingeben.")]
    [Range(0.01, 1000000, ErrorMessage = "Bitte einen positiven Wert eingeben.")]
    public decimal? Value { get; set; }
    public List<Animal> Animals { get; set; } = new();
    public decimal? AppliedRate { get; set; }
    public decimal? Result { get; set; }
}

