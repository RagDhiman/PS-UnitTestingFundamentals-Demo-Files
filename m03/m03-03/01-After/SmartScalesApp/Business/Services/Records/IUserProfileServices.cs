using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Business.Services
{
    public interface IUserProfileService
    {
        List<UserProfile> GetUserProfiles();

        UserProfile GetUserProfileByID(Guid userProfileID);

        void InsertUserProfile(UserProfile userProfile);

        void DeleteUserProfile(Guid userProfileID);

        void UpdateUserProfile(UserProfile userProfile);

        void Save();
    }
}