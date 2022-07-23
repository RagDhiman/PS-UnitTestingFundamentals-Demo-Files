using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class FeetHeightConvertorTest
    {
        [Test]
        public void ConvertFromCM_InputCMs_ReturnInFeet() 
        {
            //Arrange
            var sut = new FeetHeightConvertor();

            //Act
            var result = sut.ConvertFromCM((decimal)30.48);

            //Assert
            Assert.AreEqual((decimal)1, result);
        }

        [Test]
        public void ConvertToCM_InputFeet_ReturnInCMs() 
        {
            //Arrange
            var sut = new FeetHeightConvertor();

            //Act
            var result = sut.ConvertToCM((decimal)1);

            //Assert
            Assert.AreEqual((decimal)30.48, result);
        }
    }
}
