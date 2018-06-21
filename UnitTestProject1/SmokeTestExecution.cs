using System;
using System.Timers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TCCApplication;
using TCCApplication.Data;

namespace SmokeTest
{
    public class SmokeTestExecution
    {
        private IWebDriver _driver;
        private DriverUtilities _utilities;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            _utilities = new DriverUtilities(_driver);
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        [Test]
        public void TestLogInUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();
            Assert.AreEqual(Pages.MemberListPage, _driver.Url);
        }

        [Test]
        public void TestLoginUserWithCredentials()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LoginUserWithCredentials("email", "password");
            Assert.AreEqual(Pages.MainPage, _driver.Url);   // Expected to stay on main page since login fails
        }

        [Test]
        public void TestLogOutUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();                     // First, sign in the applicant
            appLoginLogout.LogOutUser();
            Assert.AreEqual(Pages.MainPage, _driver.Url);
        }

        [Test]
        public void TestSearchForApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant();
            //Assert.AreEqual(Pages.JasonTurleyAppProfile, _driver.Url);
        }

        [Test]
        public void TestSearchForNonExistentApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant("goak@mailinator.com", "Gary", "Oak");
        }

        [Test]
        public void TestSearchForRecommender()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForRecommender();
            //Console.ReadKey();
        }

        [Test]
        public void TestSearchForCollege()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForCollege();
        }

        [Test]
        public void TestSearchForHighSchool()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForHighSchool();
        }

        [Test]
        public void TestSearchForMembers()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForMember("Test");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Dispose();
        }
    }
}