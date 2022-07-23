namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class KilogramsWeightConvertor : IWeightConvertor
    {
        private const double PoundsInAKilogram = 0.453592;

        public decimal ConvertFromPounds(decimal weightInPounds)
        {
            return weightInPounds * ((decimal)PoundsInAKilogram);
        }

        public decimal ConvertToPounds(decimal weight)
        {
            return (weight / (decimal)PoundsInAKilogram);
        }
    }
}