using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class CardPage : PageObjectBase
    {
        private static readonly By DeleteItemButton = By.XPath("//*[@id='2_7_0_0']");
        
        public CardPage(IWebDriver driver) : base(driver)
        { }

        public void ClickOnDeleteButton()
        {
            Driver.FindElement(DeleteItemButton).Click();
        }
    }
}