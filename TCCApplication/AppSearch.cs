using System;
using OpenQA.Selenium;
using TCCApplication;
using TCCApplication.Data;

namespace TCCApplication
{
    public class AppSearch
    {
        private IWebDriver _driver;
        private AppLoginLogout app;
        private SchoolData school;

        public AppSearch(IWebDriver driver)
        {
            this._driver = driver;
            this.app = new AppLoginLogout(_driver);
            this.school = new SchoolData();
        }

        /// <summary>
        /// Search TCC for an applicant. If no parameters are given, searches for user Jason Turley
        /// </summary>
        /// <param name="email"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public void SearchForApplicant(string email = "", string firstName = "", string lastName = "")
        {
            if (email == string.Empty) { email = AppData.Email; }
            if (firstName == string.Empty) { firstName = AppData.FirstName; }
            if (lastName == string.Empty) { lastName = AppData.LastName; }

            Navigate.NavigateToSearchPage(_driver);
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
            if (email == string.Empty) { email = RecData.Email; }
            if (firstName == string.Empty) { firstName = RecData.FirstName; }
            if (lastName == string.Empty) { lastName = RecData.LastName; }
            if (id == string.Empty) { id = RecData.ID; }

            Navigate.NavigateToSearchPage(_driver);

            // Select "Recommender from drop-down menu
            _driver.FindElement(By.Id("selectSearchObject")).Click();
            _driver.FindElement(By.XPath("//option[@value='Rec']")).Click();

            EnterSearchInfo(email, firstName, lastName, id);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a college. If no parameters are given, searches for schools in Chicago, IL
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="ceebCode"></param>
        public void SearchForCollege(string schoolName = "", string city = "", string state = "", string ceebCode = "")
        {
            if (schoolName == string.Empty) { schoolName = school.SchoolName; }
            if (city == string.Empty) { city = school.City; }
            if (state == string.Empty) { state = school.State; }

            Navigate.NavigateToSearchPage(_driver);
            DriverUtilities.Wait(_driver, 10);
            _driver.FindElement(By.Id("selectSearchObject")).Click();
            _driver.FindElement(By.XPath("//option[@value='College']")).Click();

            EnterSchoolInfo(schoolName, city, state, ceebCode);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search TCC for a member
        /// </summary>
        /// <param name="memberName"></param>
        public void SearchForMember(string memberName)
        {
            app.LogInUser();
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
