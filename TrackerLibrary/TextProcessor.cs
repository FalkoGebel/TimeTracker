namespace TrackerLibrary.TextHelpers
{
    public static class TextProcessor
    {
        private const string APP_DIRECTORY = "time_tracker_data";
        private const string CATEGORY_FILE = "categories.txt";
        private const string SEPARATOR = "-|||-";
        private const string TRACKED_TIMES_FILE = "tracked_times.txt";

        /// <summary>
        /// Creates the full path for the given file name using the application data folder for the user and the defined
        /// app directory.
        /// </summary>
        /// <param name="fileName">The file name the path should be created for.</param>
        /// <returns></returns>
        public static string FullFilePath(this string fileName)
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{APP_DIRECTORY}\\{fileName}";
        }

        /// <summary>
        /// Loads the data from the category file and creates a list of category models.
        /// </summary>
        /// <returns>The created list of categorey models.</returns>
        public static List<CategoryModel> LoadCategoriesFromFile()
        {
            if (!File.Exists(CATEGORY_FILE.FullFilePath()))
            {
                return [];
            }

            List<CategoryModel> output = [];

            foreach (string line in File.ReadAllLines(CATEGORY_FILE.FullFilePath()).ToList())
            {
                string[] cols = line.Split(SEPARATOR);

                CategoryModel model = new()
                {
                    Name = cols[0],
                    Active = cols[1] == "1"
                };

                output.Add(model);
            }

            return output;
        }

        /// <summary>
        /// Loads the data from the tracked times file and creates a list of tracked time models.
        /// </summary>
        /// <returns>The created list of tracked time models.</returns>
        public static List<TrackedTimeModel> LoadTrackedTimesFromFile()
        {
            if (!File.Exists(TRACKED_TIMES_FILE.FullFilePath()))
            {
                return [];
            }

            List<TrackedTimeModel> output = [];
            List<CategoryModel> categories = LoadCategoriesFromFile();

            foreach (string line in File.ReadAllLines(TRACKED_TIMES_FILE.FullFilePath()).ToList())
            {
                string[] cols = line.Split(SEPARATOR);

                CategoryModel categoryModel = new() { Name = cols[0] };
                categoryModel.Active = categories.Find(c => c.Name == categoryModel.Name).Active;

                TrackedTimeModel model = new()
                {
                    Category = categoryModel,
                    Start = DateTime.Parse(cols[1]),
                    End = DateTime.Parse(cols[2])
                };

                output.Add(model);
            }

            return output;
        }

        /// <summary>
        /// Saves the given list of category models to the category file.
        /// </summary>
        /// <param name="categories">The list of categorey models to save.</param>
        public static void SaveCategoriesToFile(List<CategoryModel> categories)
        {
            List<string> lines = [];

            foreach (CategoryModel c in categories)
            {
                lines.Add($"{c.Name}{SEPARATOR}{(c.Active ? 1 : 0)}");
            }

            CreateBaseFolder();
            File.WriteAllLines(CATEGORY_FILE.FullFilePath(), lines);
        }

        /// <summary>
        /// Saves the given list of tracked time models to the tracked times file.
        /// </summary>
        /// <param name="trackedTimes">The list of tracked time models to save.</param>
        public static void SaveTrackedTimesToFile(List<TrackedTimeModel> trackedTimes)
        {
            List<string> lines = [];

            foreach (TrackedTimeModel tt in trackedTimes)
            {
                lines.Add($"{tt.Category.Name}{SEPARATOR}{tt.Start}{SEPARATOR}{tt.End}");
            }

            CreateBaseFolder();
            File.WriteAllLines(TRACKED_TIMES_FILE.FullFilePath(), lines);
        }

        /// <summary>
        /// Creates a separate folder in the application data folder for the current user.
        /// </summary>
        private static void CreateBaseFolder()
        {
            Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{APP_DIRECTORY}");
        }
    }
}
