﻿///<summary>
/// Search - Handles all searching done on TCC
/// </summary>
using System;
using OpenQA.Selenium;
using TCCApplication.Data;
using TCCApplication.Utilities;

namespace TCCApplication
{
    public class SearchFor
    {
        private IWebDriver _driver;
        private Navigation _navigation;
        private UserLoginLogout _userLoginLogout;
        private DriverUtilities _driverUtils;
        private DriverUtilitiesValidation _utilsValidation;

        public SearchFor(IWebDriver driver)
        {
            this._driver = driver;
            this._userLoginLogout = new UserLoginLogout(_driver);
            this._navigation = new Navigation(_driver);
            this._driverUtils = new DriverUtilities(_driver);
            this._utilsValidation = new DriverUtilitiesValidation(_driver);
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
            _navigation.NavigateToSearchPage(_driver);

            // Applicants and recommenders share email, first name, last name accessor ID names
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtEmail_fil", emailLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtFirstName_fil", firstNameLike);
            _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtLastName_fil", lastNameLike);

            // They have unique idIncludes accessor ID names
            switch (personType.ToLower())
            {
                case "applicant":
                case "applicants":
                case "app":
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCAID_fil", idIncludes);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtZipCode_fil", postalCodeLike);
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "txtCEEBCode_fil", ceebCode);
                    break;

                case "recommender":
                case "recommenders":
                case "rec":
                    // Recommenders do not have postal or CEEB codes
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
            // Select "High School" or "College" from dropdown menu
            switch (schoolType.ToLower())
            {
                case "highschool":
                case "high school":
                    _navigation.NavigateToSearchPage(_driver);
                    _utilsValidation.SelectDropdownItem("High School");
                    break;

                case "college":
                case "colleges":
                    _navigation.NavigateToSearchPage(_driver);
                    _utilsValidation.SelectDropdownItem("college");
                    break;

                case "member":
                case "members":
                    if (_driver.Url != PageValidation.MemberPage)
                    {
                        _navigation.NavigateToMemberPage(_driver, _userLoginLogout);
                    }
                    _utilsValidation.EnterText(DriverUtilities.ElementAccessorType.ID, "member-list-filter", schoolNameLike + Keys.Enter);

                    // trying to enter the below info on the member's page will result in an error. It's safer to exit.
                    return; 

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
    }
}
