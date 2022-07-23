using System.Reflection;
using NUnit.Framework;
using Moq;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Business.Models.Stats;
using System;
using SmartScalesApp.Business.Models;

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

        [Test]
        public void GetTotalWeightLossResult_ForAUserID_ReturnTotalWeightLossResultWithTotalAndMeasure() {
            //Arrange
            var sut = new StatsTotalWeightLossServices();

            //Act
            var totalWeightLossResult = sut.GetTotalWeightLossResult(Guid.NewGuid());
            
            //Assert
            Assert.IsTrue(totalWeightLossResult.TotalWeightLoss.GetType() == typeof(Decimal));
            Assert.IsTrue(Enum.IsDefined<WeightMeasure>(totalWeightLossResult.TotalWeightLossWeightMeasure));
        }
    }
}