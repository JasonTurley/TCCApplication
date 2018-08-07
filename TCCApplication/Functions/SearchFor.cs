/// <summary>
/// SearchFor.cs - Enables user to search for applicants, recommenders, high-schools, and colleges.
/// <summary>
using System;
using OpenQA.Selenium;
using TCCApplication.Data;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class SearchFor
    {
        private IWebDriver _driver;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilitiesValidation _utilsValidation;
        private UserData _userData;

        public SearchFor(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
            this._userData = new UserData();
        }

        /// <summary>
        /// Enter the arguments into an applicant's or recommender's email and name input fields.
        /// </summary>
        /// <param name="emailLike"></param>
        /// <param name="firstNameLike"></param>
        /// <param name="lastNameLike"></param>
        public void EnterSharedInfo(string emailLike, string firstNameLike, string lastNameLike)
        {
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtEmail_fil", emailLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtFirstName_fil", firstNameLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtLastName_fil", lastNameLike);
        }

        /// <summary>
        /// Searches TCC for an either an applicant or recommender depending on what is passed in for `personType`.
        /// If no type is specified, throws exception.
        /// </summary>
        /// <param name="personType">The type of person to search for. Either an applicant or recommender</param>
        /// <param name="emailLike">Full or partial email address</param>
        /// <param name="firstNameLike">Full or partial first name</param>
        /// <param name="lastNameLike">Full or partial last name</param>
        /// <param name="idLike">Full or partial identification number</param>
        /// <param name="postalCodeLike">Full or partial postal code. Note: only for applicant</param>
        /// <param name="ceebCode">Full CEEB Code. Note: only for applicant</param>
        public void SearchForPerson(string personType, string emailLike, string firstNameLike, string lastNameLike, string idIncludes, string postalCodeLike, string ceebCode)
        {
            GoToSearchPage();
                        
            // Are we searching for an applicant or recommender?
            switch (personType.ToLower())
            {
                case "applicant":
                case "applicants":
                case "app":
                    // Enter provided applicant info
                    EnterSharedInfo(emailLike, firstNameLike, lastNameLike);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCAID_fil", idIncludes);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtZipCode_fil", postalCodeLike);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCEEBCode_fil", ceebCode);
                    break;

                case "recommender":
                case "recommenders":
                case "rec":
                    // Change tab to "Recommenders" page
                    _utilsValidation.SelectDropdownItem(personType);

                    // Enter provided recommender info
                    EnterSharedInfo(emailLike, firstNameLike, lastNameLike);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtRecommederId_fil", idIncludes);
                    break;

                default:
                    throw new Exception("No `personType` specified.");
            }

            // Click search button
            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "aApplicantSearch");
        }

        /// <summary>
        /// Search TCC for a high school or college
        /// </summary>
        /// <param name="schoolType"></param>
        /// <param name="ceebCode"></param>
        /// <param name="schoolNameLike"></param>
        /// <param name="cityLike"></param>
        /// <param name="stateLike"></param>
        public void SearchForSchool(string schoolType, string ceebCode, string schoolNameLike, string cityLike, string stateLike)
        {
            GoToSearchPage();

            // Select "High School" or "College" from dropdown menu
            switch (schoolType.ToLower())
            {
                case "highschool":
                case "highschools":
                case "high school":
                case "high schools":
                    _utilsValidation.SelectDropdownItem("High School");
                    break;

                case "college":
                case "colleges":
                    _utilsValidation.SelectDropdownItem("college");
                    break;

                default:
                    throw new Exception("No `schoolType` selected.");
            }

            // Fill in the text boxes
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCEEBCode_fil", ceebCode);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtSchoolName_fil", schoolNameLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCity_fil", cityLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtState_fil", stateLike);

            _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "aApplicantSearch");
        }

        private void GoToSearchPage()
        {
            _userLoginLogout.LoginUser(_userData.GetEmail(), _userData.GetPassword());

           _utilsValidation.ExplicitWait(DriverUtilities.ElementAccessorType.ID, "loadingContainer", 30);
           _utilsValidation.Click(DriverUtilities.ElementAccessorType.ID, "loadingContainer");
           _utilsValidation.Click(DriverUtilities.ElementAccessorType.XPath, "//*[@data-bind='click:MenuBar.redirectToAppRecSearch']");
        }
    }
}