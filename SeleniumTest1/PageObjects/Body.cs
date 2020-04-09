using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class Body : PageObjectBase
    {
        private static readonly By findItem = By.XPath("//img[@alt='Blouse']");
        
        public Body(IWebDriver driver) : base(driver)
        { }

        public ProductPage ClickOnItem()
        {
            Driver.FindElement(findItem).Click();
            return new ProductPage(Driver);
        }
    }
}