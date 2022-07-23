using NUnit.Framework;
using Moq;

using System;
using System.Collections.Generic;
using System.Reflection;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Data;

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class StatsProgressServicesTest
    {
        [TestCase(180, 200, 170, 1, 15, ProgressLevel.Best)]
        [TestCase(175, 195, 180, 2, 7.69, ProgressLevel.Best)]
        [TestCase(168, 198, 182, 4, 8.08, ProgressLevel.Best)]
        public void GetProgressResults_ForAUserProfileWithWeightRecords_ReturnValidProgressResults(decimal heightInCMs,
            decimal startingWeightInPounds,
            decimal weightRecordWeight,
            Int32 sequence,
            decimal expectedPercentageLoss,
            ProgressLevel expectedProgressLevel){

            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = heightInCMs, StartingWeightInPounds = startingWeightInPounds};
            var weightRecord = new WeightRecord(userProfile.UserID, weightRecordWeight, sequence);
            var weightRecords = new List<WeightRecord>(){weightRecord};

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => 
                weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID)).Returns(weightRecords);

            var sut = new StatsProgressServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var progressResults = sut.GetProgressResults(userProfile.UserID);

            //Assert
            Assert.AreEqual(sequence, progressResults[0].Sequence);
            Assert.AreEqual(expectedPercentageLoss, progressResults[0].PercentageLoss);
            Assert.AreEqual(expectedProgressLevel, progressResults[0].ProgressLevel);

        }
    }
}