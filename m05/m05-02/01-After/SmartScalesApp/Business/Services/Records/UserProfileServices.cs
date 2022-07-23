using SmartScalesApp.Business.Models;
using SmartScalesApp.Data;

namespace SmartScalesApp.Business.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public void DeleteUserProfile(Guid userProfileID)
        {
            _userProfileRepository.DeleteUserProfile(userProfileID);
        }

        public UserProfile GetUserProfileByID(Guid userProfileID)
        {
            return _userProfileRepository.GetUserProfileByID(userProfileID);
        }

        public List<UserProfile> GetUserProfiles()
        {
            return _userProfileRepository.GetUserProfiles().ToList();
        }

        public void InsertUserProfile(UserProfile userProfile)
        {
            _userProfileRepository.InsertUserProfile(userProfile);
        }

        public void Save()
        {
            _userProfileRepository.Save();
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _userProfileRepository.UpdateUserProfile(userProfile);
        }
    }
}