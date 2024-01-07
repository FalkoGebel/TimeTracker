using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
