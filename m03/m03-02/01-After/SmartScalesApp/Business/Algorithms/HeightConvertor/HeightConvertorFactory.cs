using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public class HeightConvertorFactory
    {
        public static IHeightConvertor GetHeightConvertor(HeightMeasure heightMeasure)
        {
            switch (heightMeasure)
            {
                case HeightMeasure.Centimetres:
                    return new CentimetresHeightConvertor();

                case HeightMeasure.Feet:
                    return new FeetHeightConvertor();

                case HeightMeasure.Inches:
                    return new InchesHeightConvertor();

                case HeightMeasure.Meters:
                    return new MetersHeightConvertor();

                default:
                    return new CentimetresHeightConvertor();
            }
        }
    }
}