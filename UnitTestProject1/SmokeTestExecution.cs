using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using NUnit.Framework;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        [Test]
        public void TestMethod1()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LoginUser();
        }
    }
}
