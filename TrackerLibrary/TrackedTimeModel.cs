namespace TrackerLibrary
{
    public class TrackedTimeModel
    {
        /// <summary>
        /// Represents the category of this tracked time
        /// </summary>
        public CategoryModel Category { get; set; }

        /// <summary>
        /// Represents the start date and time of this tracked time
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Represents the end date and time of this tracked time
        /// </summary>
        public DateTime End { get; set; }
    }
}
