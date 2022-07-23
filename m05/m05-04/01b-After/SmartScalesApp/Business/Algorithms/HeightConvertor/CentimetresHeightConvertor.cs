namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public class CentimetresHeightConvertor : IHeightConvertor
    {
        private const double CMsInCM = 1;

        public decimal ConvertFromCM(decimal heightInCM)
        {
            return heightInCM / ((decimal)CMsInCM);
        }

        public decimal ConvertToCM(decimal height)
        {
            return (height * (decimal)CMsInCM);
        }
    }
}