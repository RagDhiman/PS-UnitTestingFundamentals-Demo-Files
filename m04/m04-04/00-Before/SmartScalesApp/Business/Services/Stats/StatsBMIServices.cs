using SmartScalesApp.Business.Algorithms.HeightConvertor;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services.Stats
{
    public class StatsBMIServices
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IWeightRecordRepository _weightRecordRepository;

        public StatsBMIServices(IUserProfileRepository userProfileRepository, IWeightRecordRepository weightRecordRepository)
        {
            _userProfileRepository = userProfileRepository;
            _weightRecordRepository = weightRecordRepository;
        }

        private decimal CalculateBMIForUser(Guid userProfileID)
        {
            var userProfile = _userProfileRepository.GetUserProfileByID(userProfileID);
            var weightRecords = _weightRecordRepository.GetWeightRecordsByUserID(userProfileID);
            var weightInKg = WeightConvertorFactory.GetWeightConvertor(WeightMeasure.Kilograms)
                                                    .ConvertFromPounds(userProfile.StartingWeightInPounds);
            
            if (weightRecords.Count > 0) {
                weightInKg = GetLastestWeightInKg(weightRecords);
            }

            var heightInM2 = GetHeightInM2(userProfile);

            return (weightInKg / heightInM2);
        }

        private decimal GetHeightInM2(UserProfile userProfile)
        {
            var heightInM = HeightConvertorFactory.GetHeightConvertor(HeightMeasure.Meters)
                                                    .ConvertFromCM(userProfile.HeightInCMs);

            return heightInM * heightInM;
        }

        private decimal GetLastestWeightInKg(List<WeightRecord> weightRecords)
        {
            var latestWeightRecord = weightRecords.OrderByDescending(w => w.Sequence).First();
            var weightInKg = WeightConvertorFactory.GetWeightConvertor(WeightMeasure.Kilograms)
                                                    .ConvertFromPounds(latestWeightRecord.WeightInPounds);

            return weightInKg;
        }

        private BMIClassification GetBMIClassification(decimal BMI)
        {
            switch (BMI)
            {
                case decimal n when (n < (decimal)18.5):
                    return BMIClassification.Underweight;

                case decimal n when (n < (decimal)25 && n >= (decimal)18.5):
                    return BMIClassification.Normal;

                case decimal n when (n < (decimal)30 && n >= (decimal)25):
                    return BMIClassification.Overweight;

                case decimal n when (n >= (decimal)30):
                    return BMIClassification.Obese;
            }
            return BMIClassification.Normal;
        }

        private string GetBMIClassificationRange(BMIClassification classification)
        {
            switch (classification)
            {
                case BMIClassification.Underweight:
                    return "Less than 18.5";

                case BMIClassification.Normal:
                    return "Between 18.5 and 24.9";

                case BMIClassification.Overweight:
                    return "Between 25 and 30";

                case BMIClassification.Obese:
                    return "More than 30";
            }
            return "Unknown range.";
        }

        public BMIResult GetBMIResult(Guid userProfileID)
        {
            var bmi = CalculateBMIForUser(userProfileID);

            return new BMIResult(bmi,
                        GetBMIClassification(bmi),
                        GetBMIClassificationRange(GetBMIClassification(bmi)));
        }
    }
}