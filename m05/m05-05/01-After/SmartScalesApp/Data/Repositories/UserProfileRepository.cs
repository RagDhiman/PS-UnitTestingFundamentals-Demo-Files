using CsvHelper;
using SmartScalesApp.Business.Models;
using System.Globalization;

namespace SmartScalesApp.Data
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private List<UserProfile> _userProfiles = new List<UserProfile>();
        private string _filePath;

        public UserProfileRepository(string filePath)
        {
            _filePath = filePath;
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                _userProfiles = csv.GetRecords<UserProfile>().ToList<UserProfile>();
            }
        }

        public void DeleteUserProfile(Guid userProfileID)
        {
            var itemToDelete = GetUserProfileByID(userProfileID);
            if (itemToDelete != null)
                _userProfiles.Remove(itemToDelete);
        }

        public void Dispose()
        {
        }

        public UserProfile GetUserProfileByID(Guid userProfileID)
        {
            return _userProfiles.Single(u => u.UserID == userProfileID);
        }

        public IEnumerable<UserProfile> GetUserProfiles()
        {
            return _userProfiles;
        }

        public void InsertUserProfile(UserProfile userProfile)
        {
            _userProfiles.Add(userProfile);
        }

        public void Save()
        {
            using (var writer = new StreamWriter(_filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(_userProfiles);
            }
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            var updateUserProfile = GetUserProfileByID(userProfile.UserID);
            _userProfiles.Remove(updateUserProfile);
            InsertUserProfile(userProfile);
        }
    }
}