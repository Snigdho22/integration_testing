using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class Selenium
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
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
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheSeleniumTest()
        {
            driver.Navigate().GoToUrl("https://bikroy.com/");
            driver.FindElement(By.XPath("//li[4]/a/span")).Click();
            driver.FindElement(By.Id("input_email")).Click();
            driver.FindElement(By.Id("input_email")).Clear();
            driver.FindElement(By.Id("input_email")).SendKeys("mahbubsnigdho583@gmail.com");
            driver.FindElement(By.Id("input_password")).Click();
            driver.FindElement(By.Id("input_password")).Clear();
            driver.FindElement(By.Id("input_password")).SendKeys("Karim22??");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            driver.FindElement(By.XPath("//li[3]")).Click();
            driver.FindElement(By.XPath("//li[3]/a/span")).Click();
            driver.FindElement(By.LinkText("আমার প্রোফাইল")).Click();
            driver.FindElement(By.LinkText("সেটিংস")).Click();
            driver.FindElement(By.LinkText("লগ আউট")).Click();
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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
