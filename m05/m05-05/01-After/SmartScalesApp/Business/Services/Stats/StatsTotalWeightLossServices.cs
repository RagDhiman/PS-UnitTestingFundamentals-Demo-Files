using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Models.Stats;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services.Stats
{
public class StatsTotalWeightLossServices
    {
        private IUserProfileRepository _userProfileRepository;
        private IWeightRecordRepository _weightRecordRepository;
        public StatsTotalWeightLossServices(IUserProfileRepository userProfileRepository, 
                                            IWeightRecordRepository weightRecordRepository)
        {
            _userProfileRepository = userProfileRepository;
            _weightRecordRepository = weightRecordRepository;
        }

        public TotalWeightLossResult GetTotalWeightLossResult(Guid userProfileID)
        {
            var weightRecords = _weightRecordRepository.GetWeightRecordsByUserID(userProfileID).OrderBy(w => w.Sequence);
            var userProfile = _userProfileRepository.GetUserProfileByID(userProfileID);

            var totalWeightLossResult = CreateTotalWeightLossResult(userProfile, weightRecords);

            return totalWeightLossResult;
        }

        private TotalWeightLossResult CreateTotalWeightLossResult(UserProfile userProfile, IEnumerable<WeightRecord> weightRecords) {
            var totalWeightLossResult = new TotalWeightLossResult();

            var mostRecentWeightRecord = weightRecords.OrderByDescending(w => w.Sequence).First();

            totalWeightLossResult.TotalWeightLoss = CalculateTotalWeightLoss(mostRecentWeightRecord.WeightInPounds,
                                                                            userProfile.StartingWeightInPounds,
                                                                            userProfile.WeightMeasure);

            totalWeightLossResult.TotalWeightLossWeightMeasure = userProfile.WeightMeasure;

            return totalWeightLossResult;
        }

        private decimal CalculateTotalWeightLoss(decimal mostRecentWeightInPounds, decimal startingWeight, 
                                                WeightMeasure preferredWeightMeasure) {
             decimal differenceInPounds = 0;

            if (mostRecentWeightInPounds > 0)
                 differenceInPounds = startingWeight - mostRecentWeightInPounds;

            differenceInPounds = WeightConvertorFactory.
                            GetWeightConvertor(preferredWeightMeasure).ConvertFromPounds(differenceInPounds);

            return differenceInPounds;
        }
    }
}