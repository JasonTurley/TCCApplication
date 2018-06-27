using System;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;

namespace TCCApplication
{
    public class SearchFor
    {
        private IWebDriver _driver;
        private UserLoginLogout _app;
        private UserData _user;
        private RecData _rec;
        private SchoolData _school;
        private DriverUtilities _utils;
        private Navigation _nav;

        public SearchFor(IWebDriver driver)
        {
            this._driver = driver;
            this._app = new UserLoginLogout(_driver);
            this._user = new UserData();
            this._rec = new RecData();
            this._school = new SchoolData();
            this._utils = new DriverUtilities(_driver);
            this._nav = new Navigation(_driver);
        }

        /// <summary>
        /// Search TCC for an applicant. If no parameters are given, searches for me, Jason Turley.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void SearchForApplicant(string email = "", string firstName = "", string lastName = "")
        {
            // Use my credentials
            if (email == string.Empty && firstName == string.Empty && lastName == string.Empty)
            {
                email = _user.GetEmail();
                firstName = _user.GetFirstName();
                lastName = _user.GetLastName();
            }
            
            _nav.NavigateToSearchPage(_driver);
            EnterPersonSearchInfo(email, firstName, lastName);
            DriverUtilities.ClickFirstResult(_driver);
        }

        /// <summary>
        /// Search TCC for a recommender. If no parameters are given, searches for test recommender, Helen Brown.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="id"></param>
        public void SearchForRecommender(string email = "", string firstName = "", string lastName = "", string id = "")
        {
            // Use Helen's credentials
            if (email == string.Empty && firstName == string.Empty && lastName == string.Empty && id == string.Empty)
            {
                email = _rec.GetEmail();
                firstName = _rec.GetFirstName();
                lastName = _rec.GetLastName();
                id = _rec.GetID();
            }
            
            _nav.NavigateToSearchPage(_driver);
            _nav.SelectSearch(_driver, "Rec");

            EnterPersonSearchInfo(email, firstName, lastName, id);
            DriverUtilities.ClickFirstResult(_driver);
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
            // Find Chicago school
            if (schoolName == string.Empty && city == string.Empty && state == string.Empty && ceebCode == string.Empty)
            {
                schoolName = _school.SchoolName;
                city = _school.City;
                state = _school.State;
                ceebCode = _school.CeebCode;
            }

            _nav.NavigateToSearchPage(_driver);
            _nav.SelectSearch(_driver, "college");

            EnterSchoolSearchInfo(schoolName, city, state, ceebCode);
            DriverUtilities.ClickFirstResult(_driver);
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
            // Find Chicago school
            if (schoolName == string.Empty && city == string.Empty && state == string.Empty && ceebCode == string.Empty)
            {
                schoolName = _school.SchoolName;
                city = _school.City;
                state = _school.State;
                ceebCode = _school.CeebCode;
            }

            _nav.NavigateToSearchPage(_driver);
            _nav.SelectSearch(_driver, "High School");

            EnterSchoolSearchInfo(schoolName, city, state, ceebCode);
            DriverUtilities.ClickFirstResult(_driver);
        }

        /// <summary>
        /// Search TCC for a member.
        /// </summary>
        /// <param name="memberName"></param>
        public void SearchForMember(string memberName)
        {
            _app.LogInUser();
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "member-list-filter", memberName + Keys.Enter);
            DriverUtilities.ClickFirstResult(_driver);
        }

        /// <summary>
        /// Fills out search form with provided info. Intended for both applicants and recommenders.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="idIncludes"></param>
        public void EnterPersonSearchInfo(string email = "", string firstName = "", string lastName = "", string idIncludes = "")
        {
            _utils.Wait(_driver, 10);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtEmail_fil", email);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtFirstName_fil", firstName);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtLastName_fil", lastName);

            // Applicants and recommenders have different "ID includes" fields 
            try
            {
                _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCAID_fil", idIncludes);
            }
            catch
            {
                _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtRecommederId_fil", idIncludes);
            }

            _utils.Click(DriverUtilities.ElementAccessorType.ID, "aApplicantSearch");
        }

        /// <summary>
        /// Fills out search form with provided info. Intended for both colleges and high schools.
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="ceebCode"></param>
        public void EnterSchoolSearchInfo(string schoolName = "", string city = "", string state = "", string ceebCode = "")
        {
            _utils.Wait(_driver, 10);

            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtSchoolName_fil", schoolName);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCity_fil", city);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtState_fil", state);
            _utils.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCEEBCode_fil", ceebCode);

            _utils.Click(DriverUtilities.ElementAccessorType.ID, "aApplicantSearch");
        }
    }
}
