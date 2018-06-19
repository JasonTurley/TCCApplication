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

        public AppSearch(IWebDriver driver)
        {
            this._driver = driver;
            this.app = new AppLoginLogout(_driver);
        }

        /// <summary>
        /// Search for an applicant on TCC
        /// </summary>
        /// <param name="emailLike"></param>
        /// <param name="firstNameLike"></param>
        /// <param name="lastNameLike"></param>
        public void SearchForApplicant(string emailLike = "", string firstNameLike = "", string lastNameLike = "")
        {
            if (emailLike == string.Empty) { emailLike = UserData.Email; }
            if (firstNameLike == string.Empty) { firstNameLike = UserData.FirstName; }
            if (lastNameLike == string.Empty) { lastNameLike = UserData.LastName; }

            Navigate.NavigateToSearchPage(_driver);
            EnterSearchInfo(emailLike, firstNameLike, lastNameLike);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Search for a recommender on TCC
        /// </summary>
        /// <param name="emailLike"></param>
        /// <param name="firstNameLike"></param>
        /// <param name="lastNameLike"></param>
        /// <param name="IDIncludes"></param>
        public void SearchForRecommender(string emailLike = "", string firstNameLike = "", string lastNameLike = "", string IDIncludes = "")
        {
            if (emailLike == string.Empty) { emailLike = RecData.Email; }
            if (firstNameLike == string.Empty) { firstNameLike = RecData.FirstName; }
            if (lastNameLike == string.Empty) { lastNameLike = RecData.LastName; }
            if (IDIncludes == string.Empty) { IDIncludes = RecData.ID; }

            Navigate.NavigateToSearchPage(_driver);

            // Select "Recommender from drop-down menu
            _driver.FindElement(By.Id("selectSearchObject")).Click();
            _driver.FindElement(By.XPath("//option[@value='Rec']")).Click();

            EnterSearchInfo(emailLike, firstNameLike, lastNameLike, IDIncludes);
            DriverUtilities.ClickFirstLink(_driver);
        }

        public void SearchForMember(string memberName)
        {
            app.LogInUser();
            _driver.FindElement(By.Id("member-list-filter")).SendKeys(memberName + Keys.Enter);
            DriverUtilities.ClickFirstLink(_driver);
        }

        /// <summary>
        /// Fills out search form with provided info
        /// </summary>
        /// <param name="emailLike"></param>
        /// <param name="firstNameLike"></param>
        /// <param name="lastNameLike"></param>
        /// <param name="IDIncludes"></param>
        public void EnterSearchInfo(string emailLike = "", string firstNameLike = "", string lastNameLike = "", string IDIncludes = "")
        {
            _driver.FindElement(By.Id("txtEmail_fil")).SendKeys(emailLike);
            _driver.FindElement(By.Id("txtFirstName_fil")).SendKeys(firstNameLike);
            _driver.FindElement(By.Id("txtLastName_fil")).SendKeys(lastNameLike);

            // Try to fill ApplicantId
            try
            {
                _driver.FindElement(By.Id("txtCAID_fil")).SendKeys(IDIncludes);
            }
            catch
            {
                // do nothing
            }

            // Try to fill RecommenderId
            try
            {
                _driver.FindElement(By.Id("txtRecommederId_fil")).SendKeys(IDIncludes);
            }
            catch
            {
                // do nothing
            }

            _driver.FindElement(By.Id("aApplicantSearch")).Click();
        }
    }
}
