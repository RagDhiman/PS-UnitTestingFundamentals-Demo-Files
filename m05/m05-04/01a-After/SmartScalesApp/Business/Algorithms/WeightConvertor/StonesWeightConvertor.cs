namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class StonesWeightConvertor : IWeightConvertor
    {
        private const double PoundsInAStone = 14;

        public decimal ConvertFromPounds(decimal weightInPounds)
        {
            return weightInPounds / ((decimal)PoundsInAStone);
        }

        public decimal ConvertToPounds(decimal weight)
        {
            return (weight * (decimal)PoundsInAStone);
        }
    }
}