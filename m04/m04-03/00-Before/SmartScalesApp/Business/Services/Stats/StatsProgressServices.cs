using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services.Stats
{
    public class StatsProgressServices
    {
        private IUserProfileRepository _userProfileRepository;
        private IWeightRecordRepository _weightRecordRepository;

        public StatsProgressServices(IUserProfileRepository userProfileRepository, IWeightRecordRepository weightRecordRepository)
        {
            _userProfileRepository = userProfileRepository;
            _weightRecordRepository = weightRecordRepository;
        }

        private List<ProgressResult> GenerateProgressResults(UserProfile userProfile, List<WeightRecord> weightRecords)
        {
            var progressResults = new List<ProgressResult>();

            foreach (var weightRecord in weightRecords)
            {
                var progressResult = new ProgressResult();
                progressResult.Sequence = weightRecord.Sequence;
                
                if (userProfile.StartingWeightInPounds>0)
                    progressResult.PercentageLoss = ((userProfile.StartingWeightInPounds - weightRecord.WeightInPounds) / userProfile.StartingWeightInPounds) * (decimal)100;
                
                progressResults.Add(progressResult);
            }

            SetProgressLevels(progressResults);

            return progressResults;
        }

        private void SetProgressLevels(List<ProgressResult> progressResults)
        {
            decimal highestPercentageLoss = 0;
            foreach (var progressResult in progressResults.OrderByDescending(p => p.PercentageLoss))
            {
                if (progressResult.PercentageLoss > 0 && highestPercentageLoss == 0)
                {
                    highestPercentageLoss = progressResult.PercentageLoss;
                    progressResult.ProgressLevel = ProgressLevel.Best;
                }
                else
                {
                    progressResult.ProgressLevel = ProgressLevel.Good;
                }

                if (progressResult.PercentageLoss <= 0)
                {
                    progressResult.ProgressLevel = ProgressLevel.None;
                }
            }
        }

        public List<ProgressResult> GetProgressResults(Guid userProfileID)
        {
            var weightRecords = _weightRecordRepository.GetWeightRecordsByUserID(userProfileID).OrderBy(w => w.Sequence);
            var userProfile = _userProfileRepository.GetUserProfileByID(userProfileID);

            var progressResults = GenerateProgressResults(userProfile, weightRecords.ToList());

            return progressResults;
        }
    }
}