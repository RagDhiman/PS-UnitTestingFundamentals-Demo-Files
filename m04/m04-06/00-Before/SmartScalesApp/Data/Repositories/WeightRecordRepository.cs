using CsvHelper;
using SmartScalesApp.Business.Models;
using System.Globalization;

namespace SmartScalesApp.Data
{
    public class WeightRecordRepository : IWeightRecordRepository
    {
        private readonly List<WeightRecord> _WeightRecords;
        private readonly string _filePath;

        public WeightRecordRepository(string filePath)
        {
            _filePath = filePath;
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                _WeightRecords = csv.GetRecords<WeightRecord>().ToList<WeightRecord>();
            }
        }

        public void DeleteWeightRecord(Guid WeightRecordUserID)
        {
            var itemsToDelete = GetWeightRecordsByUserID(WeightRecordUserID);
            foreach (WeightRecord itemToDelete in itemsToDelete)
                if (itemToDelete != null)
                    _WeightRecords.Remove(itemToDelete);
        }

        public void Dispose()
        {
        }

        public List<WeightRecord> GetWeightRecordsByUserID(Guid WeightRecordUserID)
        {
            return _WeightRecords.FindAll(u => u.UserID == WeightRecordUserID).OrderByDescending(w => w.Sequence).ToList();
        }

        public WeightRecord GetWeightRecordByID(Guid WeightRecordID)
        {
            return _WeightRecords.Single(u => u.RecordID == WeightRecordID);
        }

        public IEnumerable<WeightRecord> GetWeightRecords()
        {
            return _WeightRecords;
        }

        public void InsertWeightRecord(WeightRecord WeightRecord)
        {
            _WeightRecords.Add(WeightRecord);
        }

        public void Save()
        {
            using var writer = new StreamWriter(_filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(_WeightRecords);
        }

        public void UpdateWeightRecord(WeightRecord WeightRecord)
        {
            var updateWeightRecord = GetWeightRecordByID(WeightRecord.UserID);
            _WeightRecords.Remove(updateWeightRecord);
            InsertWeightRecord(WeightRecord);
        }
    }
}