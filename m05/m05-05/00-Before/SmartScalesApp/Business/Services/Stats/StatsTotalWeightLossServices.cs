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

            var totalWeightLossResult = new TotalWeightLossResult();

            var mostRecentWeightRecord = weightRecords.OrderByDescending(w => w.Sequence).First();

            decimal differenceInPounds = 0;

            if (mostRecentWeightRecord != null)
                 differenceInPounds = userProfile.StartingWeightInPounds - mostRecentWeightRecord.WeightInPounds;

            totalWeightLossResult.TotalWeightLoss = WeightConvertorFactory.
                            GetWeightConvertor(userProfile.WeightMeasure).ConvertFromPounds(differenceInPounds);

            totalWeightLossResult.TotalWeightLossWeightMeasure = userProfile.WeightMeasure;


            return totalWeightLossResult;
        }
    }
}