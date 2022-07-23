namespace SmartScalesApp.Business.Models
{
    public class BMIResult
    {
        public BMIResult(decimal bmi, BMIClassification classification, string bmiRange)
        {
            BMI = bmi;
            Classification = classification;
            BMIRange = bmiRange;
        }

        public decimal BMI { get; set; }
        public BMIClassification Classification { get; set; }
        public string BMIRange { get; set; }

        public override string ToString()
        {
            return $"BMI: {BMI} with a classification of {Classification} based on the range {BMIRange}";
        }
    }
}