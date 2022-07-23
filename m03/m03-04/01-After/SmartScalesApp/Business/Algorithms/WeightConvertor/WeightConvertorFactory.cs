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
            if (weightMeasure == WeightMeasure.Stones) {
               return new StonesWeightConvertor();
            } else if (weightMeasure == WeightMeasure.Kilograms) {
               return new KilogramsWeightConvertor();
            }

            if (weightMeasure == WeightMeasure.Pounds) {
                return new PoundsWeightConvertor();
            } else {
                return new PoundsWeightConvertor();
            }
        }
    }
}
