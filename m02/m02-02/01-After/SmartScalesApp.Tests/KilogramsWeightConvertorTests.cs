using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Tests;

[TestFixture]
public class KilogramsWeightConvertorTests
{

    [TestCase(1, 0.453592)]
    [TestCase(2.5, 1.13398)]
    [TestCase(3.8, 1.7236496)]
    public void ConvertFromPounds_InputIsInPounds_ReturnInKilograms(decimal WeightInPounds, decimal expectedWeightInKilograms)
    {
        var sut = new KilogramsWeightConvertor();

        var calculatedWeightInKilograms = sut.ConvertFromPounds(WeightInPounds);

        Assert.AreEqual(expectedWeightInKilograms, calculatedWeightInKilograms);
    }

    [TestCase(0.453592, 1)]
    [TestCase(1.13398, 2.5)]
    [TestCase(1.7236496, 3.8)]
    public void ConvertToPounds_InputIsInKilograms_ReturnInPounds(decimal WeightInKilograms, decimal expectedWeightInPounds)
    {
        var sut = new KilogramsWeightConvertor();

        var calculatedWeightInPounds = sut.ConvertToPounds(WeightInKilograms);

        Assert.AreEqual(expectedWeightInPounds, calculatedWeightInPounds);
    }
}