using NUnit.Framework;
using Moq;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Business.Models.Stats;
using System;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class StatsTotalWeightLossServicesTest
    {
        [Test]
        public void GetTotalWeightLossResult_ForAUserID_ReturnTotalWeightLossResult() {
            //Arrange
            var sut = new StatsTotalWeightLossServices();

            //Act
            var totalWeightLossResult = sut.GetTotalWeightLossResult(Guid.NewGuid());
            
            //Assert
            Assert.IsInstanceOf<TotalWeightLossResult>(totalWeightLossResult);
        }
    }
}