namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public class InchesHeightConvertor : IHeightConvertor
    {
        private const double CMsInAnInch = 2.54;

        public decimal ConvertFromCM(decimal heightInCM)
        {
            return heightInCM / ((decimal)CMsInAnInch);
        }

        public decimal ConvertToCM(decimal height)
        {
            return (height * (decimal)CMsInAnInch);
        }
    }
}