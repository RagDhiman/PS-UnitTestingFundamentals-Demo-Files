using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public class WeightConvertorFactory
    {
        private UserProfile _userProfile;
        public WeightConvertorFactory(UserProfile userProfile)
        {
            _userProfile = userProfile;
        }
        public  IWeightConvertor GetWeightConvertor() {
            return WeightConvertorFactory.GetWeightConvertor(_userProfile.WeightMeasure);
        }
        public static IWeightConvertor GetWeightConvertor(WeightMeasure weightMeasure)
        {
            switch (weightMeasure)
            {
                case WeightMeasure.Stones:
                    return new StonesWeightConvertor();

                case WeightMeasure.Kilograms:
                    return new KilogramsWeightConvertor();

                case WeightMeasure.Gallons:
                    return new GallonsWeightConvertor();

                case WeightMeasure.Pounds:
                    return new PoundsWeightConvertor();

                default:
                    return new PoundsWeightConvertor();
            }
        }
    }
}