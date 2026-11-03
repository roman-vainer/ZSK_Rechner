using ZSK_Rechner.Enums;
using ZSK_Rechner.Models;
namespace ZSK_Rechner.ViewModels;

public class CalculateViewModel
{
    public ConvertionDirection Direction { get; set; }
    public int? AnimalId { get; set; }
    public decimal? Value { get; set; }
    public List<Animal> Animals { get; set; }= new();
    public decimal? AppliedRate { get; set; }
    public decimal? Result { get; set; }
}

