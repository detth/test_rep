using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class SeleniumTest3
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private static readonly TimeSpan ImplicitWait = TimeSpan.FromSeconds(4);
        
        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
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
        public void TheUntitledTestCaseTest()
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.FindElement(By.XPath("//img[@alt='Blouse']")).Click();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.FindElement(By.XPath("//p[@id='add_to_cart']/button/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.FindElement(By.XPath("//div[@id='layer_cart']/div/div[2]/div[4]/a/span")).Click();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            driver.FindElement(By.XPath("//a[@id='2_7_0_0']/i")).Click();
            driver.Manage().Timeouts().ImplicitWait = ImplicitWait;
            
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
