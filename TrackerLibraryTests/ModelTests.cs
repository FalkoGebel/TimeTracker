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
        public void CategoryModel_is_not_null()
        {
            SutCatModel.Should().NotBeNull();
        }

        [TestMethod]
        public void TrackedTimeModel_is_not_null()
        {
            SutTrTime.Should().NotBeNull();
        }
    }
}