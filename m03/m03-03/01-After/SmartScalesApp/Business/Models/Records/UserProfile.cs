namespace SmartScalesApp.Business.Models
{
    public class UserProfile
    {
        public Guid UserID { get; set; }
        public string? UserName { get; set; }
        public HeightMeasure HeightMeasure { get; set; }
        public WeightMeasure WeightMeasure { get; set; }
        public decimal HeightInCMs { get; set; }
        public decimal StartingWeightInPounds { get; set; }

        public UserProfile()
        {
            UserID = Guid.NewGuid();
        }

        public bool ValidProfile()
        {
            if (String.IsNullOrEmpty(UserName) || HeightInCMs <= 0 || StartingWeightInPounds <= 0)
                return false;

            return true;
        }
    }
}