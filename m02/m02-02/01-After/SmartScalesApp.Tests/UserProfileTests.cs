using NUnit.Framework;
using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Tests
{
    [TestFixture]
    public class UserProfileTests
    {
        [Test]
        public void ValidProfile_InputIsValidProfile_ReturnTrue(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.HeightInCMs = 300;
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            Assert.IsTrue(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingUserName_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.HeightInCMs = 300;
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            Assert.IsFalse(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingHeight_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.StartingWeightInPounds = 150;

            var validProfile = sut.ValidProfile();

            Assert.IsFalse(validProfile);
        }

        [Test]
        public void ValidProfile_InputIsProfileMissingWeight_ReturnFalse(){
            
            var sut = new UserProfile();
            sut.UserName = "Test";
            sut.HeightInCMs = 300;

            var validProfile = sut.ValidProfile();

            Assert.IsFalse(validProfile);
        }
    }
}