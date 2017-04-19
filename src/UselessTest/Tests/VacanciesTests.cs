using NUnit.Framework;
using UselessTest.Pages;

namespace UselessTest.Tests
{
    [TestFixture]
    class VacanciesTests : BaseTest
    {
        [Test]
        public void FindCorrectPositionTest()
        {
            string expectedPosition = "Senior Automation Tests Engineer";
            string expectedCity = "Wroclaw";

            new MainPage(Driver).HoverOnMenuItem().ClickOnSubMenuItem("Vacancies");
            var wroclawVacancies = new VacanciesPage(Driver).SelectCity(expectedCity).VacanciesNamesList();
            Assert.Contains(expectedPosition, wroclawVacancies, "There isn't {0} position in {1}", expectedPosition, expectedCity);
        }

        [SetUp]
        public void Setup()
        {
            InitDriver();
            Driver.Navigate().GoToUrl(StartPage);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
