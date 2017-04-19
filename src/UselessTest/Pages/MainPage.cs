using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace UselessTest.Pages
{
    public class MainPage
    {
        By careersMenu = By.XPath("//ul[@id='menu-main-navigation-menu']/li[2]");
        string subMenuItemXpath = "//ul[@id='menu-main-navigation-menu']/li/ul/li/a[text() = '{0}']";

        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            this._driver = driver;

            if (!"Connected Consumer Technology Company | S3 Group".Equals(driver.Title))
            {
                throw new InvalidOperationException("This is not the main page");
            }
        }

        public MainPage HoverOnMenuItem()
        {
            Actions action = new Actions(_driver);
            IWebElement carrerMenu = _driver.FindElement(careersMenu);
            action.MoveToElement(carrerMenu).Build().Perform();
            return this;
        }

        public void ClickOnSubMenuItem(string menuItem)
        {
            By subMenuItem = By.XPath(string.Format(subMenuItemXpath, menuItem));
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(drv => drv.FindElement(subMenuItem));
            _driver.FindElement(subMenuItem).Click();
        }

    }
}
