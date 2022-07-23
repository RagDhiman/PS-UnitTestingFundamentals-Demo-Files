namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class PoundsWeightConvertor : IWeightConvertor
    {
        private const double PoundsInAPound = 1;

        public decimal ConvertFromPounds(decimal weightInPounds)
        {
            return weightInPounds * ((decimal)PoundsInAPound);
        }

        public decimal ConvertToPounds(decimal weight)
        {
            return (weight / (decimal)PoundsInAPound);
        }
    }
}