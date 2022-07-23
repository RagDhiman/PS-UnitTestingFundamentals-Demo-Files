using SmartScalesApp.Business.Models;

namespace SmartScalesApp.Data
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> GetUserProfiles();

        UserProfile GetUserProfileByID(Guid userProfileID);

        void InsertUserProfile(UserProfile userProfile);

        void DeleteUserProfile(Guid userProfileID);

        void UpdateUserProfile(UserProfile userProfile);

        void Save();
    }
}