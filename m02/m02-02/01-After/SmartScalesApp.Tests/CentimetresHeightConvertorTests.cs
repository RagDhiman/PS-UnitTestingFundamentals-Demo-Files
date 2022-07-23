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
        var sut = new CentimetresHeightConvertor();

        var calculatedheightInCentimetres = sut.ConvertFromCM(heightInCms);

        Assert.AreEqual(expectedheightInCentimetres, calculatedheightInCentimetres);
    }

    [TestCase(200.5, 200.5)]
    [TestCase(1, 1)]
    [TestCase(877.062, 877.062)]
    public void ConvertToCM_InputIsInCentimetres_ReturnInCMs(decimal heightInCentimetres, decimal expectedheightInCms)
    {
        var sut = new CentimetresHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInCentimetres);

        Assert.AreEqual(expectedheightInCms, calculatedheightInCMs);
    }
}