using ZSK_Rechner.Models;
namespace ZSK_Rechner.ViewModels
{
    public class RateViewModel
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = string.Empty;        
        public List<RateHistoryViewModel> RateHistory { get; set; } = new ();
    }
}
