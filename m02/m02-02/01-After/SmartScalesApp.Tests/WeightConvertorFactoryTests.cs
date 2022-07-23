using System;
using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    [TestFixture]
    public class WeightConvertorFactoryTests
    {
        [TestCase(WeightMeasure.Kilograms, typeof(KilogramsWeightConvertor))]
        [TestCase(WeightMeasure.Pounds, typeof(PoundsWeightConvertor))]
        [TestCase(WeightMeasure.Stones, typeof(StonesWeightConvertor))]
        public void GetWeightConvertor_InputIsWeightMeasure_ReturnSpecifiedConvertor(WeightMeasure WeightMeasure, Type expectedType)
        {
            IWeightConvertor convertor;

            convertor = WeightConvertorFactory.GetWeightConvertor(WeightMeasure);

            Assert.AreEqual(expectedType, convertor.GetType());
        }
    }
}