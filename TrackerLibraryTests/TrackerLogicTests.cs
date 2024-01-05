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
        public void Call_Start_with_Category_and_result_is_valid()
        {
            string categoryName = "category";
            
            TrackedTimeModel sut = TrackerLogic.Start(categoryName);

            sut.Should().NotBeNull();
            sut.Category.Should().NotBeNull();
            sut.Start.Should().BeCloseTo(DateTime.Now, new TimeSpan(0, 0, 1));
            sut.End.Should().Be(DateTime.MinValue);
            sut.Category.Name.Should().NotBeNull();
            sut.Category.Name.Should().Be(categoryName);
        }
    }
}
