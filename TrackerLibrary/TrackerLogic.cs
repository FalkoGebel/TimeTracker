using TrackerLibrary.TextHelpers;

namespace TrackerLibrary
{
    public static class TrackerLogic
    {
        private static readonly List<TrackedTimeModel> trackedTimeModels = [];

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

            categories.Remove(categories.Find(c => c.Name == categoryName));
            UpdateCategories(categories);
        }

        public static bool CategoryExists(string categoryName)
        {
            return GetCategories().Find(c => c.Name == categoryName) != null;
        }

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

        public static List<TrackedTimeModel> GetTrackedTimeModels()
        {
            return trackedTimeModels;
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
            trackedTimeModels.Add(trackedTimeModel);
        }
    }
}
