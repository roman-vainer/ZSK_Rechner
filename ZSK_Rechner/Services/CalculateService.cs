using ZSK_Rechner.Enums;

namespace ZSK_Rechner.Services
{
    public class CalculateService
    {
        public decimal Convert(decimal value, decimal rate, ConvertionDirection direction)
        {
            return direction switch
            {
                ConvertionDirection.AnimalToEuro => value * rate,
                ConvertionDirection.EuroToAnimal => value / rate,
                _ => throw new ArgumentException("Invalid conversion direction", nameof(direction)),
            };
        }
    }
}

