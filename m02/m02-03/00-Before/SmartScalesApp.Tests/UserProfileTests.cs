using NUnit.Framework;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    [TestFixture]
    public class UserProfileTests
    {
        [Test]
        public void ValidProfile_InputIsValidProfile_ReturnTrue(){
            
            var userProfile = new UserProfile();
            userProfile.UserName = "Test";
            userProfile.HeightInCMs = 300;
            userProfile.StartingWeightInPounds = 150;

            var validProfile = userProfile.ValidProfile();

            Assert.IsTrue(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingUserName_ReturnFalse(){
            
            var userProfile = new UserProfile();
            userProfile.HeightInCMs = 300;
            userProfile.StartingWeightInPounds = 150;

            var validProfile = userProfile.ValidProfile();

            Assert.IsFalse(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingHeight_ReturnFalse(){
            
            var userProfile = new UserProfile();
            userProfile.UserName = "Test";
            userProfile.StartingWeightInPounds = 150;

            var validProfile = userProfile.ValidProfile();

            Assert.IsFalse(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingWeight_ReturnFalse(){
            
            var userProfile = new UserProfile();
            userProfile.UserName = "Test";
            userProfile.HeightInCMs = 300;

            var validProfile = userProfile.ValidProfile();

            Assert.IsFalse(validProfile);
        }
    }
}