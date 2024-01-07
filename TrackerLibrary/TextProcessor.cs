using System.Collections.Generic;

namespace TrackerLibrary.TextHelpers
{
    public static class TextProcessor
    {
        private const string APP_DIRECTORY = "time_tracker_data";
        private const string CATEGORY_FILE = "categories.txt";
        private const string SEPARATOR = "-|||-";

        public static string FullFilePath(this string fileName)
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{APP_DIRECTORY}\\{fileName}";
        }

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
        /// Creates a separate folder in the application data folder for the current user.
        /// </summary>
        private static void CreateBaseFolder()
        {
            Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{APP_DIRECTORY}");
        }
    }
}
