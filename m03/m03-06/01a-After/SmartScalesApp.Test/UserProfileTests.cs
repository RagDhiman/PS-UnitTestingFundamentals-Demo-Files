using NUnit.Framework;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class UserProfileTests
    {
        [Test]
        public void SetToDefaults_ProfileWithMeasuresSet_DefaultMeasures(){
            //Arrange
            var sut = new UserProfile();

            sut.WeightMeasure = WeightMeasure.Stones;;
            sut.HeightMeasure = HeightMeasure.Feet;

            //Act
            sut.SetToDefaults();

            //Assert
            Assert.AreEqual(WeightMeasure.Pounds, sut.WeightMeasure);
            Assert.AreEqual(HeightMeasure.Centimetres, sut.HeightMeasure);
        }
    }
}