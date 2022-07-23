using System.Reflection;
using NUnit.Framework;
using Moq;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Business.Models.Stats;
using System;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class StatsTotalWeightLossServicesTest
    {
        [Test]
        public void GetTotalWeightLossResult_ForAUserID_ReturnTotalWeightLossResult() {
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 200, StartingWeightInPounds = 200};
            var weightRecord = new WeightRecord(userProfile.UserID, 200, 1);
            var weightRecords = new List<WeightRecord>(){weightRecord};

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => 
                weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID)).Returns(weightRecords);

            var sut = new StatsTotalWeightLossServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var totalWeightLossResult = sut.GetTotalWeightLossResult(userProfile.UserID);
            
            //Assert
            Assert.IsInstanceOf<TotalWeightLossResult>(totalWeightLossResult);
        }
        

        [Test]
        public void GetTotalWeightLossResult_ForAUserID_ReturnTotalWeightLossResultWithTotalAndMeasure() {
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 200, StartingWeightInPounds = 200};
            var weightRecord = new WeightRecord(userProfile.UserID, (decimal)200, 1);
            var weightRecords = new List<WeightRecord>(){weightRecord};

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => 
                weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID)).Returns(weightRecords);

            var sut = new StatsTotalWeightLossServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var totalWeightLossResult = sut.GetTotalWeightLossResult(userProfile.UserID);
            
            //Assert
            Assert.IsTrue(totalWeightLossResult.TotalWeightLoss.GetType() == typeof(Decimal));
            Assert.IsTrue(Enum.IsDefined<WeightMeasure>(totalWeightLossResult.TotalWeightLossWeightMeasure));
        }

        [TestCase(180, 200, 170, 30, WeightMeasure.Pounds)]
        [TestCase(175, 195, 180, 15, WeightMeasure.Pounds)]
        [TestCase(168, 198, 182, 16, WeightMeasure.Pounds)]
        public void GetTotalWeightLossResult_ForAUserProfileWithWeightRecords_ReturnValidTotalWeightLossResult(decimal heightInCMs,
            decimal startingWeightInPounds,
            decimal weightRecordWeight,
            decimal expectedTotalWeightLoss,
            WeightMeasure expectedWeightMeasure){

            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = heightInCMs, StartingWeightInPounds = startingWeightInPounds};
            var weightRecord = new WeightRecord(userProfile.UserID, weightRecordWeight, 1);
            var weightRecords = new List<WeightRecord>(){weightRecord};

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => 
                weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID)).Returns(weightRecords);

            var sut = new StatsTotalWeightLossServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            TotalWeightLossResult totalWeightLossResult = sut.GetTotalWeightLossResult(userProfile.UserID);

            //Assert
            Assert.AreEqual(expectedTotalWeightLoss, totalWeightLossResult.TotalWeightLoss);
            Assert.AreEqual(expectedWeightMeasure, totalWeightLossResult.TotalWeightLossWeightMeasure);

        }
    }
}