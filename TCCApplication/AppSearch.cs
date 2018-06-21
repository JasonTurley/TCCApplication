using System;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;

namespace TCCApplication
{
    public class AppSearch
    {
        private IWebDriver _driver;
        private AppLoginLogout _app;
        private UserData _user;
        private RecData _rec;
        private SchoolData _school;

        public AppSearch(IWebDriver driver)
        {
            this._driver = driver;
            this._app = new AppLoginLogout(_driver);
            this._user = new UserData();
            this._rec = new RecData();
            this._school = new SchoolData();
        }

        /// <summary>
        /// Search TCC for an applicant. If no parameters are given, searches for user Jason Turley
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void SearchForApplicant(string email = "", string firstName = "", string lastName = "")
        {
            if (email == string.Empty) { email = _user.GetEmail(); }
            if (firstName == string.Empty) { firstName = _user.GetFirstName(); }
            if (lastName == string.Empty) { lastName = _user.GetLastName(); }

            Navigate.NavigateToSearchPage(_driver);
            DriverUtilities.Wait(_driver, 10);
            EnterSearchInfo(email, firstName, lastName);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a recommender. If no parameters are given, searches for test recommender, Helen Brown
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="id"></param>
        public void SearchForRecommender(string email = "", string firstName = "", string lastName = "", string id = "")
        {
            if (email == string.Empty) { email = _rec.GetEmail(); }
            if (firstName == string.Empty) { firstName = _rec.GetFirstName(); }
            if (lastName == string.Empty) { lastName = _rec.GetLastName(); }
            if (id == string.Empty) { id = _rec.GetID(); }

            Navigate.NavigateToSearchPage(_driver);
            DriverUtilities.Wait(_driver, 10);
            Navigate.SelectSearch(_driver, "Rec");

            EnterSearchInfo(email, firstName, lastName, id);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a college. If no parameters are given, searches for schools in Chicago, IL.
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="ceebCode"></param>
        public void SearchForCollege(string schoolName = "", string city = "", string state = "", string ceebCode = "")
        {
            if (schoolName == string.Empty) { schoolName = _school.SchoolName; }
            if (city == string.Empty) { city = _school.City; }
            if (state == string.Empty) { state = _school.State; }

            Navigate.NavigateToSearchPage(_driver);
            DriverUtilities.Wait(_driver, 10);
            Navigate.SelectSearch(_driver, "college");

            EnterSchoolInfo(schoolName, city, state, ceebCode);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a high school. If no parameters are given, searches for schools in Chicago, IL.
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="ceebCode"></param>
        public void SearchForHighSchool(string schoolName = "", string city = "", string state = "", string ceebCode = "")
        {
            if (schoolName == string.Empty) { schoolName = _school.SchoolName; }
            if (city == string.Empty) { city = _school.City; }
            if (state == string.Empty) { state = _school.State; }

            Navigate.NavigateToSearchPage(_driver);
            DriverUtilities.Wait(_driver, 10);
            Navigate.SelectSearch(_driver, "High School");

            EnterSchoolInfo(schoolName, city, state, ceebCode);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a member
        /// </summary>
        /// <param name="memberName"></param>
        public void SearchForMember(string memberName)
        {
            _app.LogInUser();
            _driver.FindElement(By.Id("member-list-filter")).SendKeys(memberName + Keys.Enter);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Fills out search form with provided info
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="id"></param>
        public void EnterSearchInfo(string email = "", string firstName = "", string lastName = "", string id = "")
        {
            _driver.FindElement(By.Id("txtEmail_fil")).SendKeys(email);
            _driver.FindElement(By.Id("txtFirstName_fil")).SendKeys(firstName);
            _driver.FindElement(By.Id("txtLastName_fil")).SendKeys(lastName);

            // Try to fill ApplicantId
            try
            {
                _driver.FindElement(By.Id("txtCAID_fil")).SendKeys(id);
            }
            catch
            {
                _driver.FindElement(By.Id("txtRecommederId_fil")).SendKeys(id);
            }
            _driver.FindElement(By.Id("aApplicantSearch")).Click();
        }

        public void EnterSchoolInfo(string schoolName = "", string city = "", string state = "", string CEEBCode = "")
        {
            _driver.FindElement(By.Id("txtSchoolName_fil")).SendKeys(schoolName);
            _driver.FindElement(By.Id("txtCity_fil")).SendKeys(city);
            _driver.FindElement(By.Id("txtState_fil")).SendKeys(state);
            _driver.FindElement(By.Id("txtCEEBCode_fil")).SendKeys(CEEBCode);

            _driver.FindElement(By.Id("aApplicantSearch")).Click();
        }
    }
}
