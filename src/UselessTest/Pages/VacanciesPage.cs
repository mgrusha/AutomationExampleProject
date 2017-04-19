using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UselessTest.Pages
{
    public class VacanciesPage
    {
        By citySelector = By.XPath("//label[text() = 'Location']/../select");
        By jobsTable = By.CssSelector("table[summary='Job listings for S3 Group']");
        By vacancieName = By.XPath("//tbody/tr/td[1]");

        private readonly IWebDriver _driver;

        public VacanciesPage(IWebDriver driver)
        {
            this._driver = driver;

            if (!"Vacancies - S3 Group".Equals(driver.Title))
            {
                throw new InvalidOperationException("This is not the vacancies page");
            }
        }

        private IWebElement VacanciesTable()
        {
            return _driver.FindElement(jobsTable);
        }

        public VacanciesPage SelectCity(string cityName)
        {
            var selectElement = new SelectElement(_driver.FindElement(citySelector));
            selectElement.SelectByText(cityName);
            return this;
        }

        public List<string> VacanciesNamesList()
        {
            return VacanciesTable().FindElements(vacancieName).Select(element => element.Text).ToList();
        }



    }
}
