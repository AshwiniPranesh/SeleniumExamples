using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TestingSeleniumGmail
{
    [TestClass]
    public class FillFormIntegrationTest
    {
        public static string BaseUrl = "http://www.gmail.com";
        public const int TimeOut = 30;

        [TestMethod]
        public void CanFillAndSubmitFormAfterLogin()
        {
            var driver = new FirefoxDriver();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeOut));

            driver.Navigate().GoToUrl(BaseUrl);

            var loginBox = driver.FindElement(By.Id("Email"));
            loginBox.SendKeys("email.address@gmail.com");

            var pwBox = driver.FindElement(By.Id("Passwd"));
            pwBox.SendKeys("!SuperSecretpassw0rd");

            var signinBtn = driver.FindElement(By.Id("signIn"));
            signinBtn.Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            driver.SwitchTo().Frame("canvas_frame");

            var composeBtn = driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji T-I-KE L3']"));
            composeBtn.Click();

            var toBox = driver.FindElement(By.CssSelector("textarea[class='dK nr']"));
            toBox.SendKeys("another.email@somedomain.com");

            var subjBox = driver.FindElement(By.CssSelector("input[class='ez nr']"));
            subjBox.SendKeys("This is a test");

            var msgBox = driver.FindElement(By.CssSelector("textarea[class='Ak aXjCH']"));
            msgBox.SendKeys("This is a test email sent via Selenium Web Driver");

            var sendBtn = driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji Bq nS T-I-KE L3']>b"));
            sendBtn.Click();

        }
    }
}
