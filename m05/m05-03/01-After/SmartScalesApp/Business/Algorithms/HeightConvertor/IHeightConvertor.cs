namespace SmartScalesApp.Business.Algorithms.HeightConvertor
{
    public interface IHeightConvertor
    {
        decimal ConvertFromCM(decimal heightInCM);

        decimal ConvertToCM(decimal height);
    }
}