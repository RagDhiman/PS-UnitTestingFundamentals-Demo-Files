using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class CentimetresHeightConvertorTests
{
    [TestCase(200.5, 200.5)]
    [TestCase(1, 1)]
    [TestCase(877.062, 877.062)]
    public void ConvertFromCM_InputIsInCm_ReturnInCentimetres(decimal heightInCms, decimal expectedheightInCentimetres)
    {
        var convertor = new CentimetresHeightConvertor();

        var calculatedheightInCentimetres = convertor.ConvertFromCM(heightInCms);

        Assert.AreEqual(expectedheightInCentimetres, calculatedheightInCentimetres);
    }

    [TestCase(200.5, 200.5)]
    [TestCase(1, 1)]
    [TestCase(877.062, 877.062)]
    public void ConvertToCM_InputIsInCentimetres_ReturnInCMs(decimal heightInCentimetres, decimal expectedheightInCms)
    {
        var convertor = new CentimetresHeightConvertor();

        var calculatedheightInCMs = convertor.ConvertToCM(heightInCentimetres);

        Assert.AreEqual(expectedheightInCms, calculatedheightInCMs);
    }
}