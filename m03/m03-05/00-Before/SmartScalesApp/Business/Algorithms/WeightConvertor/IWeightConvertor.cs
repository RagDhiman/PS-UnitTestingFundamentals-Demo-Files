namespace SmartScalesApp.Business.Algorithms.WeightConvertor
{
    public interface IWeightConvertor
    {
        decimal ConvertFromPounds(decimal weightInPounds);

        decimal ConvertToPounds(decimal weight);
    }
}