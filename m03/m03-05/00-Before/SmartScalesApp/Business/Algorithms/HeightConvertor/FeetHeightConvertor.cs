namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public class FeetHeightConvertor : IHeightConvertor
    {
        private const double CMsInAFeet = 30.48;

        public decimal ConvertFromCM(decimal heightInCM)
        {
            return heightInCM / ((decimal)CMsInAFeet);
        }

        public decimal ConvertToCM(decimal height)
        {
            return (height * (decimal)CMsInAFeet);
        }
    }
}