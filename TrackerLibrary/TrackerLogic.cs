namespace TrackerLibrary
{
    public static class TrackerLogic
    {
        private static readonly List<CategoryModel> categories = [];
        private static readonly List<TrackedTimeModel> trackedTimeModels = [];

        public static void AddCategory(string categoryName)
        {
            categories.Add(new CategoryModel()
            {
                Name = categoryName,
                Active = true
            });
        }

        public static bool CategoryExists(string categoryName)
        {
            return categories.Find(c => c.Name == categoryName) != null;
        }

        public static List<TrackedTimeModel> GetTrackedTimeModels()
        {
            return trackedTimeModels;
        }

        public static void RemoveCategory(string v)
        {
            throw new NotImplementedException();
        }

        public static TrackedTimeModel Start(string categoryName)
        {
            if (categoryName == string.Empty)
                throw new ArgumentException(Properties.Resources.ERR_CATEGORY_NAME);

            CategoryModel categoryModel = categories.Find(c => c.Name == categoryName)
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
