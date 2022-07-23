using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class FeetHeightConvertorTests
{
    [TestCase(155.7528, 5.11)]
    [TestCase(30.48, 1)]
    [TestCase(182.88, 6)]
    public void ConvertFromCM_InputIsInCm_ReturnInFeet(decimal heightInCms, decimal expectedheightInFeet)
    {
        var convertor = new FeetHeightConvertor();

        var calculatedheightInFeet = convertor.ConvertFromCM(heightInCms);

        Assert.AreEqual(expectedheightInFeet, calculatedheightInFeet);
    }

    [TestCase(5.11,155.7528)]
    [TestCase(1, 30.48)]
    [TestCase(6, 182.88)]
    public void ConvertToCM_InputIsInFeet_ReturnInCMs(decimal heightInFeet, decimal expectedheightInCms)
    {
        var convertor = new FeetHeightConvertor();

        var calculatedheightInCMs = convertor.ConvertToCM(heightInFeet);

        Assert.AreEqual(expectedheightInCms, calculatedheightInCMs);
    }
}