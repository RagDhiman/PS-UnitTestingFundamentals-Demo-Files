using NUnit.Framework;
using SmartScalesApp.Business.Algorithms.WeightConvertor;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class GallonsWeightConvertorTest
    {
        [Test]
        public void ConvertFromPounds_Input8Point345Pounds_ReturnOneGallon() 
        {
            var convertor = new GallonsWeightConvertor();

            Assert.AreEqual((decimal)1, convertor.ConvertFromPounds((decimal)8.345));
        }
    }
}
