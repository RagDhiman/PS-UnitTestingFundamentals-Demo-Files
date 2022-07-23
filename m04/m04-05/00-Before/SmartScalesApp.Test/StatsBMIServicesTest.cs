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
    public class StatsBMIServicesTest
    {
        [Test]
        public void GetBMIResult_ForAUserProfileWithWeightRecord_ReturnValidBMIResult(){

            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180};
            var weightRecord = new WeightRecord(userProfile.UserID, 210, 1);
            var weightRecords = new List<WeightRecord>(){weightRecord};

            var mockUserProfileRep = new Mock<IUserProfileRepository>();
            var mockWeightRecordRep = new Mock<IWeightRecordRepository>();

            mockUserProfileRep.Setup(userProfileRep => userProfileRep.GetUserProfileByID(userProfile.UserID))
                .Returns(userProfile);

            mockWeightRecordRep.Setup(weightRecordRep => 
                weightRecordRep.GetWeightRecordsByUserID(userProfile.UserID)).Returns(weightRecords);

            var sut = new StatsBMIServices(mockUserProfileRep.Object, mockWeightRecordRep.Object);

            //Act
            var bmiResult = sut.GetBMIResult(userProfile.UserID);

            //Assert
            Assert.AreEqual(29.4, Math.Round(bmiResult.BMI, 2));
            Assert.AreEqual("Between 25 and 30", bmiResult.BMIRange);
            Assert.AreEqual(BMIClassification.Overweight, bmiResult.Classification);

        }
    }
}