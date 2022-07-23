namespace SmartScalesApp.Business.Models.Stats
{
    public class TotalWeightLossResult
    {
        public decimal TotalWeightLoss { get; set; }
        public WeightMeasure TotalWeightLossWeightMeasure { get; set; }

        public override string ToString()
        {
            return $"Total weight loss {TotalWeightLoss} {TotalWeightLossWeightMeasure}";
        }
    }
}