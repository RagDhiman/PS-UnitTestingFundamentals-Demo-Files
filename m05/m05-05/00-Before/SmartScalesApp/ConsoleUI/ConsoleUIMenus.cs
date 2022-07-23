using ConsoleTables;
using SmartScalesApp.Business.Algorithms.HeightConvertor;
using SmartScalesApp.Business.Algorithms.WeightConvertor;
using SmartScalesApp.Business.Models;
using SmartScalesApp.Business.Services;
using SmartScalesApp.Business.Services.Stats;
using SmartScalesApp.Data;

namespace SmartScalesApp.ConsoleUI
{
    public class ConsoleUIMenus
    {
        private static UserProfileService? _userProfileService;
        private static WeightRecordService? _weightRecordService;
        private StatsBMIServices? _statsBMIService;
        private StatsProgressServices? _statsProgressService;

        public bool Run()
        {
            Console.Clear();
            ConsoleOutput.WriteLine(ConsoleColor.Blue, "Smart Scales Menu");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "1) Manage user profiles");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "2) Record weight");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "3) Weight history");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "4) Calculate stats");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "5) Exit");
            var option = ConsoleInput.ReadString(ConsoleColor.Blue, "\r\nSelect an option: ");

            switch (option)
            {
                case "1":
                    ManageUserProfiles();
                    return true;

                case "2":
                    RecordWeight();
                    return true;

                case "3":
                    WeightHistory();
                    return true;

                case "4":
                    CalculateStats();
                    return true;

                case "5":
                    return false;

                default:
                    return true;
            }
        }

        public void ManageUserProfiles()
        {
            Console.Clear();
            ConsoleOutput.WriteLine(ConsoleColor.Blue, ">>> Manage user profiles");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "1) List user profiles");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "2) Create a user profile");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "3) Delete a user profile");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "4) Back to the main menu");
            var option = ConsoleInput.ReadString(ConsoleColor.Blue, "\r\nSelect an option: ");

            switch (option)
            {
                case "1":
                    ListUserProfiles();
                    break;

                case "2":
                    CreateAUserProfile();
                    break;

                case "3":
                    DeleteAUserProfile();
                    break;
            }

            Console.Clear();
        }

        public void RecordWeight()
        {
            Console.Clear();
            _userProfileService = GetUserProfileServices();
            var userprofile = SelectUserProfile(ConsoleColor.Green, "Please select user profile:", _userProfileService.GetUserProfiles());
            var weight = ConsoleInput.ReadDec($"Please enter weight in {Enum.GetName(userprofile.WeightMeasure)}:");

            var weightInPounds = WeightConvertorFactory.GetWeightConvertor(userprofile.WeightMeasure).ConvertToPounds(weight);

            _weightRecordService = GetWeightRecordServices();
            var nextWeightRecordSequence = _weightRecordService.GetNextWeightRecordSequnceForUser(userprofile.UserID);

            var weightRecord = new WeightRecord(userprofile.UserID, weightInPounds, nextWeightRecordSequence);


            _weightRecordService.InsertWeightRecord(weightRecord);
            _weightRecordService.Save();
        }

        public void WeightHistory()
        {
            _userProfileService = GetUserProfileServices();
            _weightRecordService = GetWeightRecordServices();

            var userprofile = SelectUserProfile(ConsoleColor.Green, "Please select user profile:", _userProfileService.GetUserProfiles());
            var weightRecords = _weightRecordService.GetWeightRecordsByUserID(userprofile.UserID);

            Console.Clear();
            var table = new ConsoleTable("Recorded Sequence", "Weight", "Weight Measure");
            weightRecords.ForEach(w =>
            {
                table.AddRow(w.Sequence,
                            WeightConvertorFactory.GetWeightConvertor(userprofile.WeightMeasure).ConvertFromPounds(w.WeightInPounds),
                            userprofile.WeightMeasure);
            });
            table.Write();

            ConsoleInput.ReadString(ConsoleColor.Blue, "Press [Enter] to navigate home");
        }

        public void CalculateStats()
        {
            Console.Clear();
            ConsoleOutput.WriteLine(ConsoleColor.Blue, ">>> Calculate Stats");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "1) User BMI");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "2) User progress");
            ConsoleOutput.WriteLine(ConsoleColor.DarkCyan, "3) Back to the main menu");
            var option = ConsoleInput.ReadString(ConsoleColor.Blue, "\r\nSelect an option: ");

            switch (option)
            {
                case "1":
                    CalculateBMI();
                    break;

                case "2":
                    CalculateProgress();
                    break;
            }
        }

        public void CalculateBMI()
        {
            Console.Clear();
            _userProfileService = GetUserProfileServices();
            _statsBMIService = GetStatsBMIService();

            var userprofile = SelectUserProfile(ConsoleColor.Blue, "Please select the user profile to calculate BMI for:", _userProfileService.GetUserProfiles());
            var bmiResult = _statsBMIService.GetBMIResult(userprofile.UserID);

            Console.Clear();
            var table = new ConsoleTable($"{userprofile.UserName} BMI", "Classification", "Range");
            table.AddRow(String.Format("{0:0.##}", bmiResult.BMI), bmiResult.Classification, bmiResult.BMIRange);
            table.Options.EnableCount = false;
            table.Write();

            ConsoleOutput.WriteLine(String.Empty);
            ConsoleInput.ReadString(ConsoleColor.Blue, "Press [Enter] to navigate home");
        }

        public void CalculateProgress()
        {
            Console.Clear();
            _userProfileService = GetUserProfileServices();
            _statsProgressService = GetStatsProgressService();

            var userprofile = SelectUserProfile(ConsoleColor.Blue, "Please select the user profile to calculate progress for:", _userProfileService.GetUserProfiles());
            var progressResults = _statsProgressService.GetProgressResults(userprofile.UserID);

            Console.Clear();
            var table = new ConsoleTable();
            table.Columns.Clear();
            table.Columns.Add("Sequence");
            table.Columns.Add("Percentage");
            table.Columns.Add("Classification");

            foreach (var progressResult in progressResults.OrderByDescending(p => p.Sequence))
            {
                table.AddRow(progressResult.Sequence, String.Format("{0:0.##}", progressResult.PercentageLoss), progressResult.ProgressLevel);
            }
            table.Options.EnableCount = false;
            table.Write();
            ConsoleOutput.WriteLine(String.Empty);
            ConsoleInput.ReadString(ConsoleColor.Blue, "Press [Enter] to navigate home");
        }

        public void ListUserProfiles()
        {
            Console.Clear();
            _userProfileService = GetUserProfileServices();
            var userprofiles = _userProfileService.GetUserProfiles();

            var table = new ConsoleTable("User", "Height", "Height Measure", "Starting Weight", "Weight Measure");
            userprofiles.ForEach(u =>
            {
                table.AddRow(u.UserName,
                    HeightConvertorFactory.GetHeightConvertor(u.HeightMeasure).ConvertFromCM(u.HeightInCMs),
                    u.HeightMeasure,
                    String.Format("{0:0.##}", WeightConvertorFactory.GetWeightConvertor(u.WeightMeasure).ConvertFromPounds(u.StartingWeightInPounds)),
                    u.WeightMeasure);
            });
            table.Write();

            ConsoleOutput.WriteLine(String.Empty);
            ConsoleInput.ReadString(ConsoleColor.Blue, "Press [Enter] to navigate home");
        }

        public void CreateAUserProfile()
        {
            _userProfileService = GetUserProfileServices();

            Console.Clear();
            var newUserProfile = new UserProfile();
            newUserProfile.UserName = ConsoleInput.ReadString("Please enter name for profile:");
            Console.Clear();
            newUserProfile.HeightMeasure = ConsoleInput.ReadEnum<HeightMeasure>("Please select the preferred height measure:");
            Console.Clear();
            newUserProfile.WeightMeasure = ConsoleInput.ReadEnum<WeightMeasure>("Please select the preferred weight measure:");
            Console.Clear();
            var height = ConsoleInput.ReadDec($"Please enter your height in {newUserProfile.HeightMeasure.ToString().ToLower()}:");
            newUserProfile.HeightInCMs = HeightConvertorFactory.GetHeightConvertor(newUserProfile.HeightMeasure)
                                            .ConvertToCM(height);
            Console.Clear();
            var weight = ConsoleInput.ReadDec($"Please enter your starting weight in {newUserProfile.WeightMeasure.ToString().ToLower()}:");
            newUserProfile.StartingWeightInPounds = WeightConvertorFactory.GetWeightConvertor(newUserProfile.WeightMeasure)
                                            .ConvertToPounds(weight);
            Console.Clear();

            if (newUserProfile.ValidProfile())
            {
                ConsoleOutput.WriteLine(ConsoleColor.Green, $"Profile for {newUserProfile.UserName} created!");
                _userProfileService.InsertUserProfile(newUserProfile);
                _userProfileService.Save();
            }

            ConsoleInput.ReadString("Press [Enter] to navigate home");
        }

        public void DeleteAUserProfile()
        {
            Console.Clear();
            _userProfileService = GetUserProfileServices();
            var userprofile = SelectUserProfile(ConsoleColor.Red, "Please select the user profile to delete:", _userProfileService.GetUserProfiles());
            _userProfileService.DeleteUserProfile(userprofile.UserID);
            _userProfileService.Save();
        }

        private UserProfileService GetUserProfileServices()
        {
            if (_userProfileService != null)
                return _userProfileService;
            return new UserProfileService(new UserProfileRepository("Data/DataFiles/UserProfiles"));
        }

        private WeightRecordService GetWeightRecordServices()
        {
            if (_weightRecordService != null)
                return _weightRecordService;
            return new WeightRecordService(new WeightRecordRepository("Data/DataFiles/WeightRecords"));
        }

        private StatsBMIServices GetStatsBMIService()
        {
            return new StatsBMIServices(new UserProfileRepository("Data/DataFiles/UserProfiles"),
                                         new WeightRecordRepository("Data/DataFiles/WeightRecords"));
        }

        private StatsProgressServices GetStatsProgressService()
        {
            return new StatsProgressServices(new UserProfileRepository("Data/DataFiles/UserProfiles"),
                                         new WeightRecordRepository("Data/DataFiles/WeightRecords"));
        }

        private UserProfile SelectUserProfile(ConsoleColor colour, string prompt, List<UserProfile> userprofiles)
        {
            Console.Clear();
            ConsoleOutput.WriteLine(colour, "User profiles:");
            int i = 0;
            userprofiles.ForEach(u =>
            {
                i++;
                Console.WriteLine($"{i}) {u.UserName}");
            });

            var recordToDelete = ConsoleInput.ReadInt(colour, prompt, 1, i);
            return userprofiles.ToArray()[recordToDelete - 1];
        }
    }
}