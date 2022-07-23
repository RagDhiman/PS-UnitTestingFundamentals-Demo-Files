namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public class MetersHeightConvertor : IHeightConvertor
    {
        private const double CMsInAMeter = 100;

        public decimal ConvertFromCM(decimal heightInCM)
        {
            return heightInCM / (decimal)CMsInAMeter;
        }

        public decimal ConvertToCM(decimal height)
        {
            return (height * (decimal)CMsInAMeter);
        }
    }
}