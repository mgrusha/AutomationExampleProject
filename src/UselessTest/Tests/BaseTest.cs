using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UselessTest.Tests
{
    public class BaseTest
    {
        protected string StartPage = "http://www.s3group.com/";
        protected IWebDriver Driver { get; set; }

        protected void InitDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }
    }
}
