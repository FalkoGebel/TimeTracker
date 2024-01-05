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
    }
}