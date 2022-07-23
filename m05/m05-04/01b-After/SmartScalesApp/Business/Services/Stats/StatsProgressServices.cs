using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services.Stats
{
    public class StatsProgressServices
    {
        private IUserProfileRepository _userProfileRepository;
        private IWeightRecordRepository _weightRecordRepository;

        public IUserProfileRepository UserProfileRepository { get {return _userProfileRepository;}}

        public IWeightRecordRepository WeightRecordRepository { get {return _weightRecordRepository;}}

        public StatsProgressServices(IUserProfileRepository userProfileRepository, IWeightRecordRepository weightRecordRepository)
        {
            _userProfileRepository = userProfileRepository;
            _weightRecordRepository = weightRecordRepository;
        }

        public List<ProgressResult> GetProgressResults(Guid userProfileID)
        {
            var weightRecords = _weightRecordRepository.GetWeightRecordsByUserID(userProfileID).OrderBy(w => w.Sequence);
            var userProfile = _userProfileRepository.GetUserProfileByID(userProfileID);

            var progressResults = CreateProgressResultsList(userProfile, weightRecords.ToList());

            SetProgressLevels(progressResults);

            return progressResults;
        }

        public List<ProgressResult> CreateProgressResultsList(UserProfile userProfile, List<WeightRecord> weightRecords)
        {
            var progressResults = new List<ProgressResult>();

            foreach (var weightRecord in weightRecords)
            {
                var progressResult = GenerateProgressResultForUserWeightRecord(userProfile.StartingWeightInPounds, weightRecord);
                progressResults.Add(progressResult);
            }
            return progressResults;
        }

        public ProgressResult GenerateProgressResultForUserWeightRecord(decimal startingWeightInPounds, WeightRecord weightRecord) {
                var progressResult = new ProgressResult();
                progressResult.Sequence = weightRecord.Sequence;
                
                if (startingWeightInPounds>0)
                    progressResult.PercentageLoss = CalculatePercentageLoss(startingWeightInPounds, weightRecord.WeightInPounds);
                
                return progressResult;
        }

        public decimal CalculatePercentageLoss(decimal startingWeightInPounds, decimal weightInPounds) {
            return Math.Round(((startingWeightInPounds - weightInPounds) / startingWeightInPounds) * (decimal)100, 2);
        }

        public void SetProgressLevels(List<ProgressResult> progressResults)
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
    }
}