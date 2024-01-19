using FluentAssertions;
using TrackerLibrary;

namespace TrackerLibraryTests
{
    [TestClass]
    public class ModelTests
    {
        private CategoryModel? SutCatModel;
        private TrackedTimeModel? SutTrTime;

        [TestInitialize]
        public void Initialize()
        {
            SutCatModel = new CategoryModel();
            SutTrTime = new TrackedTimeModel();
        }

        [TestMethod]
        public void CategoryModel_constructed_correctly()
        {
            SutCatModel.Should().NotBeNull();
            SutCatModel.Name.Should().BeNull();
            SutCatModel.Active.Should().BeFalse();
        }

        [TestMethod]
        public void TrackedTimeModel_constructed_correctly()
        {
            SutTrTime.Should().NotBeNull();
            SutTrTime.Category.Should().BeNull();
            SutTrTime.Start.Should().Be(DateTime.MinValue);
            SutTrTime.End.Should().Be(DateTime.MinValue);
        }

        [TestMethod]
        public void TrackedTimeModel_get_correct_duration_1()
        {
            SutTrTime.Start = new DateTime(2024, 1, 14, 20, 14, 14);
            SutTrTime.End = new DateTime(2024, 1, 14, 20, 17, 14);
            SutTrTime.Duration.Should().Be("00:03");
        }

        [TestMethod]
        public void TrackedTimeModel_get_correct_duration_2()
        {
            SutTrTime.Start = new DateTime(2024, 1, 14, 20, 59, 14);
            SutTrTime.End = new DateTime(2024, 1, 14, 21, 11, 14);
            SutTrTime.Duration.Should().Be("00:12");
        }

        [TestMethod]
        public void TrackedTimeModel_get_correct_duration_3()
        {
            SutTrTime.Start = new DateTime(2024, 1, 14, 20, 14, 14);
            SutTrTime.End = new DateTime(2024, 1, 14, 21, 17, 14);
            SutTrTime.Duration.Should().Be("01:03");
        }

        [TestMethod]
        public void TrackedTimeModel_get_correct_duration_4()
        {
            SutTrTime.Start = new DateTime(2024, 1, 14, 20, 14, 14);
            SutTrTime.End = new DateTime(2024, 1, 14, 20, 17, 13);
            SutTrTime.Duration.Should().Be("00:03");
        }

        [TestMethod]
        public void TrackedTimeModel_get_correct_duration_5()
        {
            SutTrTime.Start = new DateTime(2024, 1, 14, 20, 14, 14);
            SutTrTime.End = new DateTime(2024, 1, 14, 22, 29, 27);
            SutTrTime.Duration.Should().Be("02:15");
        }
    }
}