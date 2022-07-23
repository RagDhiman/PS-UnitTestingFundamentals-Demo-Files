using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class HeightConvertorFactoryTest
    {
        [Test]
        public void GetHeightConvertor_ForUserProfileWithFeetMeasure_ReturnFeetHeightConvertor() {
            //Arrange
            var userProfile = new UserProfile();
            userProfile.HeightMeasure = HeightMeasure.Feet;
            var sut = new HeightConvertorFactory(userProfile);
            //Act
            var convertor = sut.GetHeightConvertor();
            //Assert
            Assert.AreEqual(typeof(FeetHeightConvertor), convertor.GetType());
        }
    }
}
