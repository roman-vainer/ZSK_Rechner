namespace ZSK_Rechner.ViewModels
{
    public class RateHistoryViewModel
    {
        public DateTime ValidFrom { get; set; }
        public decimal Rate { get; set; }
        public decimal? PreviousRate { get; set; }
        public decimal ChangeRate { get; set; }
    }
}
