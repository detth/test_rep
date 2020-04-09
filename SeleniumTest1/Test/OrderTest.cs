using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.PageObjects;


namespace SeleniumTests
{
    [TestFixture]
    public class OrderTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        private static readonly TimeSpan ImplicitWait = TimeSpan.FromSeconds(4);
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            verificationErrors = new StringBuilder();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            Body mainPage = new Body(driver);
            ProductPage productPage = mainPage.ClickOnItem();
            productPage.ClickOnAddToCardButton();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            productPage.ClickOnProceedToCheckout();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void AddItemToCardTest()
        {
            
            
            
            //driver.FindElement(By.XPath("//a[@id='2_7_0_0']/i")).Click();

            //driver.FindElement(By.LinkText("Blouse"));
            
            
            try
            {
                Assert.AreEqual("Blouse", driver.FindElement(By.LinkText("Blouse")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            
        }

        [Test]
        public void AddAndDeleteItemFromCardTest()
        {
            
            CardPage cardPage = new CardPage(driver);
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            cardPage.ClickOnDeleteButton();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;

            try
            {
                Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='center_column']/p")), driver.FindElement(By.XPath("//*[@id='center_column']/p")));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
