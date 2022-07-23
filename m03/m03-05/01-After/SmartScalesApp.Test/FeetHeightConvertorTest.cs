using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class FeetHeightConvertorTest
    {
        [Test]
        public void Convert_CMs_Feet() 
        {
            //Arrange
            var sut = new FeetHeightConvertor();

            //Act
            var resultOne = sut.ConvertFromCM((decimal)30.48);
            var resultTwo = sut.ConvertToCM((decimal)1.0);


            //Assert
            Assert.AreEqual((decimal)1, resultOne);
            Assert.AreEqual((decimal)30.48, resultTwo);
        }
        
        [Test]
        public void ConvertFromCM_Input30Point48CMs_Return1Foot() 
        {
            //Arrange
            var sut = new FeetHeightConvertor();

            //Act
            var result = sut.ConvertFromCM((decimal)30.48);

            //Assert
            Assert.AreEqual((decimal)1, result);
        }

        [Test]
        public void ConvertToCM_Input1Foot_ReturnIn30Point48CMs() 
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