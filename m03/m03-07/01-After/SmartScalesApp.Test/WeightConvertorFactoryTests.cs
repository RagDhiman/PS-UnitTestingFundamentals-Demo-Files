using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using System;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class WeightConvertorFactoryTests
    {
        private UserProfile _userProfile = new UserProfile(); 

        [SetUp]
        public void init() {
                _userProfile.UserName = "Test User";
                _userProfile.HeightMeasure = HeightMeasure.Meters;
                _userProfile.HeightInCMs = 210;
                _userProfile.StartingWeightInPounds = 180;
        }


        /*
        [Test]
        public void GetWeightConvertor_ForUserProfile_ReturnDefaultWeightConvertor() {
            //Arrange
            var sut = new WeightConvertorFactory(_userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(PoundsWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithStonesWeightMeasure_ReturnStonesWeightConvertor() {
            //Arrange
            _userProfile.WeightMeasure = WeightMeasure.Stones;
            var sut = new WeightConvertorFactory(_userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(StonesWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithKilogramsWeightMeasure_ReturnKilogramsWeightConvertor() {
            //Arrange
             _userProfile.WeightMeasure = WeightMeasure.Kilograms;
            var sut = new WeightConvertorFactory(_userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(KilogramsWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithGallonsWeightMeasure_ReturnGallonsWeightConvertor() {
            //Arrange
            _userProfile.WeightMeasure = WeightMeasure.Gallons;
            var sut = new WeightConvertorFactory(_userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(GallonsWeightConvertor), convertor.GetType());
        }
        */

        [TestCase(typeof(KilogramsWeightConvertor), WeightMeasure.Kilograms)]
        [TestCase(typeof(PoundsWeightConvertor), WeightMeasure.Pounds)]
        [TestCase(typeof(StonesWeightConvertor), WeightMeasure.Stones)]
        public void GetWeightConvertor_InputIsWeightMeasure_ReturnSpecifiedConvertor(Type expectedType, WeightMeasure weightMeasure)
        {
            //Arrange
             _userProfile.WeightMeasure = weightMeasure;
            var sut = new WeightConvertorFactory(_userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(expectedType, convertor.GetType());
        }
    }
}