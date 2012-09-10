using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Web.UI.Tests
{
    [TestClass]
    public class FillFormIntegrationTest
    {
        public static string BaseUrl = "http://acswatercooler.heroku.com";
        public const int TimeOut = 30;

        [TestMethod]
        public void CanFillAndSubmitFormAfterLogin()
        {
            var driver = new FirefoxDriver();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeOut));

            driver.Navigate().GoToUrl(BaseUrl + "/signin");

            driver.FindElement(By.Id("session_email")).SendKeys("just.testing@email.com");
            driver.FindElement(By.Id("session_password")).SendKeys("abc123");

            driver.FindElement(By.Id("session_submit")).Click();

            Assert.AreEqual("ACS Technologies Water Cooler | Just Testing", driver.Title);

            driver.FindElement(By.LinkText("Home")).Click();

            Assert.AreEqual("ACS Technologies Water Cooler | Home", driver.Title);

            driver.FindElement(By.Id("micropost_content")).SendKeys("This is a test from Selenium");

            driver.FindElement(By.Id("micropost_submit")).Click();
        }
    }
}
