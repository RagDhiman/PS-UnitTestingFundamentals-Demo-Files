using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class InchesHeightConvertorTests
{
    [TestCase(509.27, 200.5)]
    [TestCase(2.54, 1)]
    [TestCase(877.062, 345.3)]
    public void ConvertFromCM_InputIsInCm_ReturnInInches(decimal heightInCms, decimal expectedheightInInches)
    {
        var sut = new InchesHeightConvertor();

        var calculatedheightInInches = sut.ConvertFromCM(heightInCms);

        Assert.AreEqual(expectedheightInInches, calculatedheightInInches);
    }

    [TestCase(200.5, 509.27)]
    [TestCase(1, 2.54)]
    [TestCase(345.3, 877.062)]
    public void ConvertToCM_InputIsInInches_ReturnInCMs(decimal heightInInches, decimal expectedheightInCms)
    {
        var sut = new InchesHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInInches);

        Assert.AreEqual(expectedheightInCms, calculatedheightInCMs);
    }
}