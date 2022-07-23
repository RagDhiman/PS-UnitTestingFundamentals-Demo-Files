using System.Reflection;
using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.HeightConvertor;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class InchesHeightConvertorTests
    {
        /*
        [Test]
        public void ConvertFromCM_TwoPointFiftyFourCMs_ReturnOneInch()
        {
            var sut = new InchesHeightConvertor();

            var calculatedHeightInInches = sut.ConvertFromCM((decimal)2.54);

            Assert.AreEqual((decimal)1.0, calculatedHeightInInches);
        }
        
        [Test]
        public void ConvertFromCM_FivePointZeroEightCMs_ReturnTwoInches()
        {
            var sut = new InchesHeightConvertor();

            var calculatedHeightInInches = sut.ConvertFromCM((decimal)5.08);

            Assert.AreEqual((decimal)2.0, calculatedHeightInInches);
        }
        
        [Test]
        public void ConvertFromCM_SevenPointSixTwoCMs_ReturnThreeInches()
        {
            var sut = new InchesHeightConvertor();

            var calculatedHeightInInches = sut.ConvertFromCM((decimal)7.62);

            Assert.AreEqual((decimal)3.0, calculatedHeightInInches);
        }
        */

        [TestCase(1, 2.54)]
        [TestCase(2, 5.08)]
        [TestCase(3, 7.62)]
        public void ConvertFromCM_InputIsInCm_ReturnInInches(decimal expectedHeightInInches, decimal heightInCms)
        {
            var sut = new InchesHeightConvertor();

            var calculatedHightInInches = sut.ConvertFromCM(heightInCms);

            Assert.AreEqual(expectedHeightInInches, calculatedHightInInches);
        }
    }
}