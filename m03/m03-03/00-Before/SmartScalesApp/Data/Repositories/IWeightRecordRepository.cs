using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Data
{
    public interface IWeightRecordRepository
    {
        IEnumerable<WeightRecord> GetWeightRecords();

        List<WeightRecord> GetWeightRecordsByUserID(Guid WeightRecordUserID);

        WeightRecord GetWeightRecordByID(Guid WeightRecordID);

        void InsertWeightRecord(WeightRecord WeightRecord);

        void DeleteWeightRecord(Guid WeightRecordUserID);

        void UpdateWeightRecord(WeightRecord WeightRecord);

        void Save();
    }
}