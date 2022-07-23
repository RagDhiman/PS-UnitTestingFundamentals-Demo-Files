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
    public class StatsProgressServicesBrittleTest
    {
        [Test]
        public void Constructor_SetsRepositories_RepositoriesSet() {
            //Arrange
            var userProfileRep = new Mock<IUserProfileRepository>();
            var weightRecordRep = new Mock<IWeightRecordRepository>();
            StatsProgressServices sut;

            //Act
            sut = new StatsProgressServices(userProfileRep.Object, weightRecordRep.Object);
            
            //Assert
            Assert.NotNull(sut.WeightRecordRepository);
            Assert.NotNull(sut.UserProfileRepository);
        }

        [Test]
        public void SetProgressLevels_ForProgressResultsGiven_SetProgressLevel() {
            //Arrange
            var userProfileRep = new Mock<IUserProfileRepository>();
            var weightRecordRep = new Mock<IWeightRecordRepository>();
            var sut = new StatsProgressServices(userProfileRep.Object, weightRecordRep.Object);

            var progressResults = new List<ProgressResult>();

            progressResults.Add(new ProgressResult(){Sequence = 1, PercentageLoss = -5});
            progressResults.Add(new ProgressResult(){Sequence = 2, PercentageLoss = 20});
            progressResults.Add(new ProgressResult(){Sequence = 3, PercentageLoss = 30});

            //Act
            sut.SetProgressLevels(progressResults);
            
            //Assert
            Assert.AreEqual(ProgressLevel.None, progressResults[0].ProgressLevel);
            Assert.AreEqual(ProgressLevel.Good, progressResults[1].ProgressLevel);
            Assert.AreEqual(ProgressLevel.Best, progressResults[2].ProgressLevel);
        }


        [TestCase(202,185,8.42)]
        [TestCase(300,285,5)]
        [TestCase(350,250,28.57)]
        [TestCase(143,122,14.69)]
        public void CalculatePercentageLoss_UsingStartingWeightAndWeight_ReturnPercentageLoss(decimal startingWeightInPounds, decimal weightInPounds, decimal expectedPercentageLoss) {
              //Arrange
            var userProfileRep = new Mock<IUserProfileRepository>();
            var weightRecordRep = new Mock<IWeightRecordRepository>();

            var sut = new StatsProgressServices(userProfileRep.Object, weightRecordRep.Object);

            //Act
            var result = sut.CalculatePercentageLoss(startingWeightInPounds, weightInPounds);

            //Assert
            Assert.AreEqual((decimal)expectedPercentageLoss, result);          
        }

        [Test]
        public void GetProgressResults_ForAUserProfileWithWeightRecords_VerifyWeCallDependencies(){

            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180, StartingWeightInPounds = 200};
            var weightRecord = new WeightRecord(userProfile.UserID, 170, 1);
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
            mockUserProfileRep.Verify(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID), Times.Once);
            mockWeightRecordRep.Verify(weightRecordRep => weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID), Times.Once);

        }
    }
}