using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public abstract class PageObjectBase
    {
        protected readonly IWebDriver Driver;

        protected PageObjectBase(IWebDriver driver) => Driver = driver;
    }
}