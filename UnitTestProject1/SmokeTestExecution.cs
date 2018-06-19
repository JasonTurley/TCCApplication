﻿using System;
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

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new FirefoxDriver();
            System.IO.Directory.SetCurrentDirectory(TestContext.CurrentContext.WorkDirectory);
        }

        [Test]
        public void TestLogInUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);
            appLoginLogout.LogInUser();
            DriverUtilities.Wait(_driver, 5);
            Assert.AreEqual(Pages.MemberListPage, _driver.Url);
        }

        [Test]
        public void TestLogOutUser()
        {
            AppLoginLogout appLoginLogout = new AppLoginLogout(_driver);

            // First, sign in the applicant
            appLoginLogout.LogInUser();

            // Next, sign them out
            appLoginLogout.LogOutUser();
            DriverUtilities.Wait(_driver, 5);
            Assert.AreEqual(Pages.MainPage, _driver.Url);
        }

        [Test]
        public void TestSearchForApplicant()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForApplicant("", "Paul");  // hard coded for now
            //Console.ReadKey();                                                // stop window from closing
        }

        [Test]
        public void TestSearchForRecommender()
        {
            AppSearch appSearch = new AppSearch(_driver);
            appSearch.SearchForRecommender();
            //Console.ReadKey();
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