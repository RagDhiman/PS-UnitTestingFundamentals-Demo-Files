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
    public class UserProfileServiceTest
    {
        [Test]
        public void InsertUserProfile_WithValidUserProfile_CallsInsertOnRepository() {
            //Arrange
            var userProfile = new UserProfile() {HeightInCMs = 180};
            var mockUserProfileRep = new Mock<IUserProfileRepository>();

            var sut = new UserProfileService(mockUserProfileRep.Object);

            //Act
            sut.InsertUserProfile(userProfile);

            //Assert
            mockUserProfileRep.Verify(x => x.InsertUserProfile(userProfile), Times.Once);
        }
    }
}