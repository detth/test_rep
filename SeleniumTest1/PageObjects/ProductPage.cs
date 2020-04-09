using OpenQA.Selenium;

namespace SeleniumTests.PageObjects
{
    public class ProductPage : PageObjectBase
    {
        private static readonly By addToCardButton = By.XPath("//p[@id='add_to_cart']/button/span");
        private static readonly By proceedToCheckout = By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a");
        public ProductPage(IWebDriver driver) : base(driver)
        { }

        public void ClickOnAddToCardButton()
        {
            Driver.FindElement(addToCardButton).Click();
        }

        public void ClickOnProceedToCheckout()
        {
            Driver.FindElement(proceedToCheckout).Click();
        }
    }
}