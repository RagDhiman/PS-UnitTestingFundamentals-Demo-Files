using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using System;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class WeightConvertorFactoryTests
    {
        private UserProfile CreateUserProfile() {
            var userProfile = new UserProfile();
            userProfile.UserName = "Test User";
            userProfile.HeightInCMs = 210;
            userProfile.StartingWeightInPounds = 180;
            return userProfile;
        }

        [Test]
        public void GetWeightConvertor_ForUserProfile_ReturnDefaultWeightConvertor() {
            //Arrange
            var userProfile = CreateUserProfile();
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(PoundsWeightConvertor), convertor.GetType());
        }

        [Test]
        public void GetWeightConvertor_ForUserProfileWithStonesWeightMeasure_ReturnStonesWeightConvertor() {
            //Arrange
            var userProfile = CreateUserProfile();
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
            var userProfile = CreateUserProfile();
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
            var userProfile = CreateUserProfile();
            userProfile.WeightMeasure = WeightMeasure.Gallons;
            var sut = new WeightConvertorFactory(userProfile);

            //Act
            var convertor = sut.GetWeightConvertor();

            //Assert
            Assert.AreEqual(typeof(GallonsWeightConvertor), convertor.GetType());
        }
    }
}
