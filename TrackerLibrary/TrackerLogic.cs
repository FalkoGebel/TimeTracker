using TrackerLibrary.TextHelpers;

namespace TrackerLibrary
{
    public static class TrackerLogic
    {
        /// <summary>
        /// Activates the given category.
        /// </summary>
        /// <param name="categoryName">Category to activate.</param>
        public static void ActivateCategory(string categoryName)
        {
            var categories = GetCategories();
            categories.Find(c => c.Name == categoryName).Active = true;
            UpdateCategories(categories);
        }

        public static void AddCategory(string categoryName)
        {
            var categories = GetCategories();

            if (categories.Find(c => c.Name == categoryName) != null)
                return;

            categories.Add(new CategoryModel()
            {
                Name = categoryName,
                Active = true
            });
            UpdateCategories(categories);
        }

        public static void RemoveCategory(string categoryName)
        {
            var categories = GetCategories();

            if (categories.Find(c => c.Name == categoryName) == null)
                return;

            DeleteTrackedTimesForCategory(categoryName);

            categories.Remove(categories.Find(c => c.Name == categoryName));
            UpdateCategories(categories);
        }

        public static void DeleteTrackedTimesForCategory(string categoryName)
        {
            List<TrackedTimeModel> trackedTimes = GetTrackedTimes();
            trackedTimes = trackedTimes.Where(tt => tt.Category.Name != categoryName).ToList();
            UpdateTrackedTimes(trackedTimes);
        }

        public static bool CategoryExists(string categoryName)
        {
            return GetCategories().Find(c => c.Name == categoryName) != null;
        }

        /// <summary>
        /// Deactivates the given category.
        /// </summary>
        /// <param name="categoryName">Category to deactivate.</param>
        public static void DeactivateCategory(string categoryName)
        {
            var categories = GetCategories();
            categories.Find(c => c.Name == categoryName).Active = false;
            UpdateCategories(categories);
        }

        public static List<CategoryModel> GetCategories()
        {
            return TextProcessor.LoadCategoriesFromFile();
        }

        public static void UpdateCategories(List<CategoryModel> categories)
        {
            TextProcessor.SaveCategoriesToFile(categories);
        }

        public static void UpdateTrackedTimes(List<TrackedTimeModel> trackedTimes)
        {
            TextProcessor.SaveTrackedTimesToFile(trackedTimes);
        }

        public static List<TrackedTimeModel> GetTrackedTimes()
        {
            return TextProcessor.LoadTrackedTimesFromFile();
        }

        public static TrackedTimeModel Start(string categoryName)
        {
            if (categoryName == string.Empty)
                throw new ArgumentException(Properties.Resources.ERR_CATEGORY_NAME);

            CategoryModel categoryModel = GetCategories().Find(c => c.Name == categoryName)
                ?? throw new ArgumentException(Properties.Resources.ERR_CATEGORY_NOT_FOUND.Replace("{category_name}", categoryName));
            
            if (!categoryModel.Active)
                throw new ArgumentException(Properties.Resources.ERR_CATEGORY_NOT_ACTIVE.Replace("{category_name}", categoryName));

            return new TrackedTimeModel()
            { 
                Category = categoryModel,
                Start = DateTime.Now
            };
        }

        public static void Stop(TrackedTimeModel trackedTimeModel)
        {
            if (trackedTimeModel == null)
                throw new ArgumentException(Properties.Resources.ERR_TTM);

            if (trackedTimeModel.Category == null)
                throw new ArgumentException(Properties.Resources.ERR_TTM_CM);

            if (trackedTimeModel.Start == DateTime.MinValue)
                throw new ArgumentException(Properties.Resources.ERR_TTM_START);

            trackedTimeModel.End = DateTime.Now;

            List<TrackedTimeModel> trackedTimes = GetTrackedTimes();
            trackedTimes.Add(trackedTimeModel);
            UpdateTrackedTimes(trackedTimes);
        }
    }
}
