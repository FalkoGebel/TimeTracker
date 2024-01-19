namespace TrackerLibrary
{
    public class TrackedTimeModel
    {
        /// <summary>
        /// Represents the category of this tracked time.
        /// </summary>
        public CategoryModel? Category { get; set; }

        /// <summary>
        /// Represents the start date and time of this tracked time.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Represents the end date and time of this tracked time.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Represents the duration of this trackted time rounded to the nearest minute
        /// as string with hours and minutes.
        /// </summary>
        public string Duration
        {
            get
            {
                TimeSpan roundTo = TimeSpan.FromMinutes(1);
                TimeSpan timeSpan = End - Start;
                long ticks = (long)(Math.Round(timeSpan.Ticks / (double)roundTo.Ticks) * roundTo.Ticks);
                timeSpan = new TimeSpan(ticks);
                return $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}";
            }
         }
    }
}
