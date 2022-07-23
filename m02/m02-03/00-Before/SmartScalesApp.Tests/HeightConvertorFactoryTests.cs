using System;
using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    [TestFixture]
    public class HeightConvertorFactoryTests
    {
        [TestCase(HeightMeasure.Centimetres, typeof(CentimetresHeightConvertor))]
        [TestCase(HeightMeasure.Inches, typeof(InchesHeightConvertor))]
        [TestCase(HeightMeasure.Meters, typeof(MetersHeightConvertor))]
        [TestCase(HeightMeasure.Feet, typeof(FeetHeightConvertor))]
        public void ConvertFromCM_InputIsInCm_ReturnInFeet(HeightMeasure heightMeasure, Type expectedType)
        {
            IHeightConvertor convertor;

            convertor = HeightConvertorFactory.GetHeightConvertor(heightMeasure);

            Assert.AreEqual(expectedType, convertor.GetType());
        }
    }
}