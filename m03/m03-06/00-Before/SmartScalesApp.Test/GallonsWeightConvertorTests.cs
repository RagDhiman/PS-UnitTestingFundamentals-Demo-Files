using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class GallonsWeightConvertorTests
    {
        [Test]
        public void ConvertFromPounds_InputTwoPounds_ReturnInGallons() 
        {
            //Arrange
            var sut = new GallonsWeightConvertor();

            //Act
            var result = sut.ConvertFromPounds((decimal)8.345);

            //Assert
            Assert.AreEqual((decimal)1, result);
        }
    }
}