namespace SmartScalesApp.Business.Models
{
    public class ProgressResult
    {
        public Int32 Sequence { get; set; }
        public decimal PercentageLoss { get; set; }
        public ProgressLevel ProgressLevel { get; set; }

        public override string ToString()
        {
            return $"Total percentage loss {PercentageLoss} which in terms of progress is classified as {ProgressLevel}";
        }
    }
}