using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Business.Services
{
    public interface IWeightRecordService
    {
        List<WeightRecord> GetWeightRecords();

        List<WeightRecord> GetWeightRecordsByUserID(Guid WeightRecordUserID);

        WeightRecord GetWeightRecordByID(Guid WeightRecordID);

        void InsertWeightRecord(WeightRecord WeightRecord);

        void DeleteWeightRecord(Guid WeightRecordID);

        void UpdateWeightRecord(WeightRecord WeightRecord);

        void Save();
    }
}