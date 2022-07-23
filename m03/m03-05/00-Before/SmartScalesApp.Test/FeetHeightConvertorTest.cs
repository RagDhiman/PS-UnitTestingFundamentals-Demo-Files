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
    }
}