using NUnit.Framework;
using Moq;

using System;
using System.Collections.Generic;
using System.Reflection;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Services;
using SmartScalesApp.Data; 

namespace SmartScalesApp.Test
{
    [TestFixture]
    public class UserProfileService_IntegrationTest
    {
        [Test]
        public void InsertUserProfile_WithValidUserProfile_UserProfileIsSavedToFile() {
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180};
            var UserProfileRep = new UserProfileRepository("DataFiles/UserProfiles");

            var sut = new UserProfileService(UserProfileRep);

            //Act
            sut.InsertUserProfile(userProfile);

            //Assert
            var newUserProfile = sut.GetUserProfileByID(userProfile.UserID);

            Assert.AreEqual(userProfile.UserID, newUserProfile.UserID);
            Assert.AreEqual(userProfile.HeightInCMs, newUserProfile.HeightInCMs);

        }
    }
}