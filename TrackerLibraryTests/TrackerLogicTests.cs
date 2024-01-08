using FluentAssertions;
using System.Globalization;
using TrackerLibrary;

namespace TrackerLibraryTests
{
    [TestClass]
    public class TrackerLogicTests
    {
        [TestInitialize]
        public void Initialize()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            var categories = TrackerLogic.GetCategories();
            while (categories.Count > 0)
            {
                TrackerLogic.RemoveCategory(categories[0].Name);
                categories = TrackerLogic.GetCategories();
            }
        }

        [TestMethod]
        public void Call_Start_without_Category_and_exception()
        {
            Action act = () => TrackerLogic.Start("");

            act.Should().Throw<ArgumentException>().WithMessage("No category name specified");
        }

        [TestMethod]
        public void Call_Start_without_Category_and_exception_in_german()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            Action act = () => TrackerLogic.Start("");

            act.Should().Throw<ArgumentException>().WithMessage("Kein Kategorienname vorgegeben");
        }

        [TestMethod]
        public void Call_CategoryExists_with_invalid_category_and_return_false()
        {
            TrackerLogic.CategoryExists("Reading").Should().BeFalse();
        }

        [TestMethod]
        public void Call_AddCategory_with_new_category_and_category_exists()
        {
            TrackerLogic.AddCategory("Writing");
            TrackerLogic.CategoryExists("Writing").Should().BeTrue();
        }

        [TestMethod]
        public void Call_Start_with_Category_and_result_is_valid()
        {
            string categoryName = "Programming";

            TrackerLogic.AddCategory(categoryName);
            TrackedTimeModel sut = TrackerLogic.Start(categoryName);

            sut.Should().NotBeNull();
            sut.Category.Should().NotBeNull();
            sut.Start.Should().BeCloseTo(DateTime.Now, new TimeSpan(0, 0, 1));
            sut.End.Should().Be(DateTime.MinValue);
            sut.Category.Name.Should().NotBeNull();
            sut.Category.Name.Should().Be(categoryName);
        }

        [TestMethod]
        public void Call_Stop_without_TrackedTimeModel_and_exception()
        {
            TrackedTimeModel sut = null;
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("TrackedTimeModel must not be \"null\"");
        }

        [TestMethod]
        public void Call_Stop_without_TrackedTimeModel_and_exception_in_german()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            TrackedTimeModel sut = null;
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("TrackedTimeModel darf nicht \"null\" sein");
        }

        [TestMethod]
        public void Call_Stop_without_Category_and_exception()
        {
            TrackedTimeModel sut = new ()
            {
                Category = null
            };
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("Category in TrackedTimeModel must not be \"null\"");
        }

        [TestMethod]
        public void Call_Stop_without_Category_and_exception_in_german()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            TrackedTimeModel sut = new()
            {
                Category = null
            };
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("Category in TrackedTimeModel darf nicht \"null\" sein");
        }

        [TestMethod]
        public void Call_Stop_without_Start_and_exception()
        {
            CategoryModel categoryModel = new()
            {
                Name = "category"
            };
            TrackedTimeModel sut = new()
            {
                Category = categoryModel
            };
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("No Start specified in TrackedTimeModel");
        }

        [TestMethod]
        public void Call_Stop_without_Start_and_exception_in_german()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            CategoryModel categoryModel = new()
            {
                Name = "category"
            };
            TrackedTimeModel sut = new()
            {
                Category = categoryModel
            };
            Action act = () => TrackerLogic.Stop(sut);

            act.Should().Throw<ArgumentException>().WithMessage("Kein Start in TrackedTimeModel spezifiziert");
        }

        [TestMethod]
        public void Call_Stop_wit_correct_data_and_new_TrackedTimeModel_with_Stop_in_list()
        {
            string categoryName = "category";
            TrackerLogic.AddCategory(categoryName);

            var inputTrackedTimeModel = TrackerLogic.Start(categoryName);
            TrackerLogic.Stop(inputTrackedTimeModel);
            TrackedTimeModel sut = TrackerLogic.GetTrackedTimes().Last();
            sut.Category.Name.Should().Be(categoryName);
            sut.End.Should().BeCloseTo(DateTime.Now, new TimeSpan(0, 0, 1));
        }

        [TestMethod]
        public void Active_Category_returns_active_true()
        {
            string categoryName = "Writing";

            TrackerLogic.AddCategory(categoryName);
            CategoryModel sut = TrackerLogic.GetCategories().Find(c => c.Name == categoryName);
            sut.Active.Should().BeTrue();
        }

        [TestMethod]
        public void Inactivated_Category_returns_active_false()
        {
            string categoryName = "Reading";

            TrackerLogic.AddCategory(categoryName);
            TrackerLogic.DeactivateCategory(categoryName);
            CategoryModel sut = TrackerLogic.GetCategories().Find(c => c.Name == categoryName);
            sut.Active.Should().BeFalse();
        }

        [TestMethod]
        public void Activated_Category_returns_active_true()
        {
            string categoryName = "Programming";

            TrackerLogic.AddCategory(categoryName);
            TrackerLogic.DeactivateCategory(categoryName);
            TrackerLogic.ActivateCategory(categoryName);
            CategoryModel sut = TrackerLogic.GetCategories().Find(c => c.Name == categoryName);
            sut.Active.Should().BeTrue();
        }

        [TestMethod]
        public void Remove_Category_and_category_and_tracked_times_are_gone()
        {
            TrackerLogic.AddCategory("Writing");
            TrackerLogic.AddCategory("Reading");

            string unexpectedCategory = "Gaming";
            TrackerLogic.AddCategory(unexpectedCategory);

            TrackedTimeModel ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Reading");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Reading");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start(unexpectedCategory);
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Reading");
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start(unexpectedCategory);
            TrackerLogic.Stop(ttm);
            ttm = TrackerLogic.Start("Writing");
            TrackerLogic.Stop(ttm);

            List<CategoryModel> categories = TrackerLogic.GetCategories();
            List<TrackedTimeModel> trackedTimes = TrackerLogic.GetTrackedTimes();

            categories.Count(c => c.Name == unexpectedCategory).Should().Be(1);
            trackedTimes.Count(tt => tt.Category.Name == unexpectedCategory).Should().Be(2);

            TrackerLogic.RemoveCategory(unexpectedCategory);

            categories = TrackerLogic.GetCategories();
            trackedTimes = TrackerLogic.GetTrackedTimes();

            categories.Count(c => c.Name == unexpectedCategory).Should().Be(0);
            trackedTimes.Count(tt => tt.Category.Name == unexpectedCategory).Should().Be(0);
        }
    }
}
