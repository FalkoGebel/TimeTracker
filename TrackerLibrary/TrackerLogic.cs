namespace TrackerLibrary
{
    public static class TrackerLogic
    {
        public static TrackedTimeModel Start(string categoryName)
        {
            if (categoryName == string.Empty)
                throw new ArgumentException(Properties.Resources.ERROR_NO_CATEGORY_NAME);

            return new TrackedTimeModel()
            {
                Category = new CategoryModel()
                {
                    Name = categoryName
                },
                Start = DateTime.Now
            };
        }
    }
}
