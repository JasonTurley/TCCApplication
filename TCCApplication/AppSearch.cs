using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
        /// Goto App Search Rec page. Assumes the user is already logged in
        /// </summary>
        public void NavigateToSearchPage()
        {
            // Log in the user if they are not already
            if (app.IsLoggedIn() == false)
            {
                app.LogInUser();
            }
            DriverUtilities.Wait(this._driver, 5);
            _driver.FindElement(By.Id("loadingContainer")).Click();
            _driver.FindElement(By.XPath("//*[@id='left-panel']/nav/ul/li[3]/a")).Click();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailLike"></param>
        /// <param name="firstNameLike"></param>
        /// <param name="lastNameLike"></param>
        public void SearchForApplicant(string emailLike, string firstNameLike = "", string lastNameLike = "")
        {
            NavigateToSearchPage();
            
            // Enter search criteria
            _driver.FindElement(By.Id("txtEmail_fil")).SendKeys(emailLike);
            _driver.FindElement(By.Id("txtFirstName_fil")).SendKeys(firstNameLike);
            _driver.FindElement(By.Id("txtLastName_fil")).SendKeys(lastNameLike);

            _driver.FindElement(By.Id("aApplicantSearch")).Click();
        }


        public void SearchForRecommender()
        {
            NavigateToSearchPage();

            // Select "Recommender from drop-down menu
            _driver.FindElement(By.Id("selectSearchObject")).Click();
            _driver.FindElement(By.XPath("//option[@value='Rec']")).Click();
            
        }
    }
}
