using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class MetersHeightConvertorTests
{


    [TestCase(98.3, 0.983)]
    [TestCase(198.5, 1.985)]
    [TestCase(222, 2.22)]
    public void ConvertFromCM_InputIsInCm_ReturnInMeters(decimal heightInCms, decimal expectedheightInMeters)
    {
        var sut = new MetersHeightConvertor();

        var calculatedheightInMeters = sut.ConvertFromCM(heightInCms);

        Assert.AreEqual(expectedheightInMeters, calculatedheightInMeters);
    }

    [TestCase(0.983, 98.3)]
    [TestCase(1.985, 198.5)]
    [TestCase(2.22, 222)]
    public void ConvertToCM_InputIsInMeters_ReturnInCMs(decimal heightInMeters, decimal expectedheightInCms)
    {
        var sut = new MetersHeightConvertor();

        var calculatedheightInCMs = sut.ConvertToCM(heightInMeters);

        Assert.AreEqual(expectedheightInCms, calculatedheightInCMs);
    }
}