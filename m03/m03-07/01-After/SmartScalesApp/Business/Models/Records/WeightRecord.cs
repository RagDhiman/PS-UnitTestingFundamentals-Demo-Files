namespace SmartScalesApp.Business.Models
{
    public class WeightRecord
    {
        public Guid RecordID { get; set; }
        public Int32 Sequence { get; set; }
        public Guid UserID { get; set; }
        public decimal WeightInPounds { get; set; }
        public WeightRecord(){}
        public WeightRecord(Guid userID, decimal weightInPounds, Int32 nextWeightRecordSequence)
        {
            RecordID = System.Guid.NewGuid();
            UserID = userID;
            WeightInPounds = weightInPounds;
            Sequence = nextWeightRecordSequence;
        }

        public bool ValidWeightRecord()
        {
            if (WeightInPounds <= 0)
                return false;

            return true;
        }
    }
}