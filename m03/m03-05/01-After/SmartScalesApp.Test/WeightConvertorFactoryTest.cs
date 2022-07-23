using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using System;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class WeightConvertorFactoryTest
    {
        [Test]
        public void GetWeightConvertor_ForUserProfile_WeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();

            Type expectedConvertorType;
            switch (userProfile.WeightMeasure)
            {
                case WeightMeasure.Kilograms:
                    expectedConvertorType = typeof(KilogramsWeightConvertor);
                    break;
                case WeightMeasure.Pounds:
                    expectedConvertorType = typeof(PoundsWeightConvertor);
                    break;
                case WeightMeasure.Stones:
                    expectedConvertorType = typeof(StonesWeightConvertor);
                    break;
                case WeightMeasure.Gallons:
                    expectedConvertorType = typeof(GallonsWeightConvertor);
                    break;
                default:
                    expectedConvertorType = typeof(PoundsWeightConvertor);
                    break;
            }

            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(expectedConvertorType, convertor.GetType());
        }
        
        [Test]
        public void GetWeightConvertor_ForUserProfile_ReturnDefaultWeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(PoundsWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithStonesWeightMeasure_ReturnStonesWeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();
            userProfile.WeightMeasure = WeightMeasure.Stones;
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(StonesWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithKilogramsWeightMeasure_ReturnKilogramsWeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();
            userProfile.WeightMeasure = WeightMeasure.Kilograms;
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(KilogramsWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithGallonsWeightMeasure_ReturnGallonsWeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();
            userProfile.WeightMeasure = WeightMeasure.Gallons;
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(GallonsWeightConvertor), convertor.GetType());
        }
    }
}