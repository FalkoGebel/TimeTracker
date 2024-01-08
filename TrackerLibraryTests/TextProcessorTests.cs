using FluentAssertions;
using TrackerLibrary;
using TrackerLibrary.TextHelpers;

namespace TrackerLibraryTests
{
    [TestClass]
    public class TextProcessorTests
    {
        [TestMethod]
        public void Call_FullPath_with_fileName_and_correct_full_path()
        {
            string fileName = "test.txt";
            fileName.FullFilePath().Should().Be(@"C:\Users\Falko\AppData\Roaming\time_tracker_data\test.txt");
        }

        [TestMethod]
        public void Save_Categories_to_file_and_file_exists()
        {
            List<CategoryModel> categories =
            [
                new CategoryModel { Name = "Programming", Active = true },
                new CategoryModel { Name = "Writing", Active = false },
                new CategoryModel { Name = "Reading", Active = true }
            ];

            TextProcessor.SaveCategoriesToFile(categories);
            File.Exists(@"C:\Users\Falko\AppData\Roaming\time_tracker_data\categories.txt").Should().BeTrue();
        }

        [TestMethod]
        public void Load_Categories_from_file_and_correct_list()
        {
            List<CategoryModel> expectedCategories =
            [
                new CategoryModel { Name = "Programming", Active  = true },
                new CategoryModel { Name = "Writing", Active  = false },
                new CategoryModel { Name = "Reading", Active  = true }
            ];

            TextProcessor.SaveCategoriesToFile(expectedCategories);
            List<CategoryModel> actualCategories = TextProcessor.LoadCategoriesFromFile();
            actualCategories.Should().BeEquivalentTo(expectedCategories);
        }

        [TestMethod]
        public void Save_Tracked_Times_to_file_and_file_exists()
        {
            CategoryModel cmp = new() { Name = "Programming", Active = true };
            CategoryModel cmw = new() { Name = "Writing", Active = true };

            List<TrackedTimeModel> trackedTimes =
            [
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 02, 27, 22, 55, 33), End = new DateTime(2023, 02, 27, 23, 23, 22) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 05, 21, 11, 11, 11), End = new DateTime(2023, 05, 21, 12, 11, 11) },
                new TrackedTimeModel { Category = cmw, Start = new DateTime(2023, 07, 27, 19, 25, 33), End = new DateTime(2023, 07, 27, 20, 23, 22) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 09, 15, 18, 12, 25), End = new DateTime(2023, 09, 16, 01, 05, 13) },
                new TrackedTimeModel { Category = cmw, Start = new DateTime(2023, 12, 28, 09, 30, 45), End = new DateTime(2023, 12, 28, 09, 45, 51) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2024, 01, 05, 20, 00, 47), End = new DateTime(2024, 01, 05, 23, 45, 01) }
            ];

            TextProcessor.SaveTrackedTimesToFile(trackedTimes);
            File.Exists(@"C:\Users\Falko\AppData\Roaming\time_tracker_data\tracked_times.txt").Should().BeTrue();
        }

        [TestMethod]
        public void Load_Tracked_Times_from_file_and_correct_list()
        {
            CategoryModel cmp = new() { Name = "Programming", Active = true };
            CategoryModel cmw = new() { Name = "Writing", Active = true };

            List<CategoryModel> categories = [ cmp, cmw ];

            TextProcessor.SaveCategoriesToFile(categories);

            List<TrackedTimeModel> expectedTrackedTimes =
            [
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 02, 27, 22, 55, 33), End = new DateTime(2023, 02, 27, 23, 23, 22) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 05, 21, 11, 11, 11), End = new DateTime(2023, 05, 21, 12, 11, 11) },
                new TrackedTimeModel { Category = cmw, Start = new DateTime(2023, 07, 27, 19, 25, 33), End = new DateTime(2023, 07, 27, 20, 23, 22) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2023, 09, 15, 18, 12, 25), End = new DateTime(2023, 09, 16, 01, 05, 13) },
                new TrackedTimeModel { Category = cmw, Start = new DateTime(2023, 12, 28, 09, 30, 45), End = new DateTime(2023, 12, 28, 09, 45, 51) },
                new TrackedTimeModel { Category = cmp, Start = new DateTime(2024, 01, 05, 20, 00, 47), End = new DateTime(2024, 01, 05, 23, 45, 01) }
            ];

            TextProcessor.SaveTrackedTimesToFile(expectedTrackedTimes);
            List<TrackedTimeModel> actualTrackedTimes = TextProcessor.LoadTrackedTimesFromFile();
            actualTrackedTimes.Should().BeEquivalentTo(expectedTrackedTimes);
        }
    }
}
