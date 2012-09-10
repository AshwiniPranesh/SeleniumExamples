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

            driver.FindElement(By.Id("Email")).SendKeys("email.address@gmail.com");
            driver.FindElement(By.Id("Passwd")).SendKeys("!SuperSecretpassw0rd");

            driver.FindElement(By.Id("signIn")).Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));

            driver.SwitchTo().Frame("canvas_frame");
            driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji T-I-KE L3']")).Click();


            driver.FindElement(By.CssSelector("textarea[class='dK nr']")).SendKeys("another.email@somedomain.com");
            driver.FindElement(By.CssSelector("input[class='ez nr']")).SendKeys("This is a test");
            driver.FindElement(By.CssSelector("textarea[class='Ak aXjCH']")).SendKeys("This is a test email sent via Selenium Web Driver");
            driver.FindElement(By.CssSelector("div[class='T-I J-J5-Ji Bq nS T-I-KE L3']>b")).Click();

        }
    }
}
