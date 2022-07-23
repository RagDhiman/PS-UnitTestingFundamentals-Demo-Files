using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services
{
    public class WeightRecordService : IWeightRecordService
    {
        private readonly IWeightRecordRepository _WeightRecordRepository;

        public WeightRecordService(IWeightRecordRepository WeightRecordRepository)
        {
            _WeightRecordRepository = WeightRecordRepository;
        }

        public void DeleteWeightRecord(Guid WeightRecordID)
        {
            _WeightRecordRepository.DeleteWeightRecord(WeightRecordID);
        }

        public WeightRecord GetWeightRecordByID(Guid WeightRecordID)
        {
            return _WeightRecordRepository.GetWeightRecordByID(WeightRecordID);
        }

        public List<WeightRecord> GetWeightRecordsByUserID(Guid WeightRecordUserID)
        {
            return _WeightRecordRepository.GetWeightRecordsByUserID(WeightRecordUserID);
        }

        public Int32 GetNextWeightRecordSequnceForUser(Guid WeightRecordUserID)
        {
            var weightRecords = _WeightRecordRepository.GetWeightRecordsByUserID(WeightRecordUserID);
            if (weightRecords.Count > 0)
                return weightRecords.OrderByDescending(w => w.Sequence).First().Sequence + 1;

            return 1;    
        }
        
        public List<WeightRecord> GetWeightRecords()
        {
            return _WeightRecordRepository.GetWeightRecords().ToList();
        }

        public void InsertWeightRecord(WeightRecord WeightRecord)
        {
            _WeightRecordRepository.InsertWeightRecord(WeightRecord);
        }

        public void Save()
        {
            _WeightRecordRepository.Save();
        }

        public void UpdateWeightRecord(WeightRecord WeightRecord)
        {
            _WeightRecordRepository.UpdateWeightRecord(WeightRecord);
        }
    }
}