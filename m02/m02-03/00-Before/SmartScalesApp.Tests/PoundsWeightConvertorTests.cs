using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class PoundsWeightConvertorTests
{
    [TestCase(2.5, 2.5)]
    [TestCase(6, 6)]
    [TestCase(222, 222)]
    public void ConvertFromPounds_InputIsInPounds_ReturnInPounds(decimal WeightInPounds, decimal expectedWeightInPounds)
    {
        var convertor = new PoundsWeightConvertor();

        var calculatedWeightInPounds = convertor.ConvertFromPounds(WeightInPounds);

        Assert.AreEqual(expectedWeightInPounds, calculatedWeightInPounds);
    }

    [TestCase(2.5, 2.5)]
    [TestCase(6, 6)]
    [TestCase(222, 222)]
    public void ConvertToPounds_InputIsInPounds_ReturnInPounds(decimal WeightInPounds, decimal expectedWeightInPounds)
    {
        var convertor = new PoundsWeightConvertor();

        var calculatedWeightInPounds = convertor.ConvertToPounds(WeightInPounds);

        Assert.AreEqual(expectedWeightInPounds, calculatedWeightInPounds);
    }
}