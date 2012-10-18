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

            var loginBox = driver.FindElement(By.Id("session_email"));
            loginBox.SendKeys("just.testing@email.com");

            var pwdBox = driver.FindElement(By.Id("session_password"));
            pwdBox.SendKeys("abc123");

            var submitBtn = driver.FindElement(By.Id("session_submit"));
            submitBtn.Click();

            Assert.AreEqual("ACS Technologies Water Cooler | Just Testing", driver.Title);

            var homeBtn = driver.FindElement(By.LinkText("Home"));
            homeBtn.Click();

            Assert.AreEqual("ACS Technologies Water Cooler | Home", driver.Title);

            var mpBox = driver.FindElement(By.Id("micropost_content"));
            mpBox.SendKeys("This is a test from Selenium");

            var submitMp = driver.FindElement(By.Id("micropost_submit"));
            submitMp.Click();
        }
    }
}
