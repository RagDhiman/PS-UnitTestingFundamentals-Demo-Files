using NUnit.Framework;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    [TestFixture]
    public class WeightRecordTestsTests
    {
        [Test]
        public void ValidWeightRecord_InputIsValid_ReturnTrue(){
            
            var userID = System.Guid.NewGuid();;
            var weightRecord = new WeightRecord(userID, 234, 1);

            var validweightRecord = weightRecord.ValidWeightRecord();

            Assert.IsTrue(validweightRecord);
        }

        [Test]
        public void ValidWeightRecord_InputHasInvalidWeight_ReturnFalse(){
            
            var userID = System.Guid.NewGuid();;
            var weightRecord = new WeightRecord(userID, 0, 1);

            var validweightRecord = weightRecord.ValidWeightRecord();

            Assert.IsFalse(validweightRecord);
        }
    }    
}