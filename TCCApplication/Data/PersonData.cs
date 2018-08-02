/// <summary>
/// PersonData.cs - Abstract class. The protected member functions can only be used in derived classes. 
/// </summary>
namespace TCCApplication.Data
{
    // Base class for Applicants and Recommenders
    public class PersonData
    {
        protected string FirstName;
        protected string LastName;
        protected string Email;
        protected string Password;
        protected string ID;

        protected PersonData()
        {

        }

        protected PersonData(string firstName, string lastName, string email, string password, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.ID = id;
        }

        protected void UpdateInfo(string newFirstName, string newLastName, string id = "")
        {
            this.FirstName = newFirstName;
            this.LastName = newLastName;
            this.ID = id;
        }

        protected void UpdateLoginInfo(string newEmail, string newPassword)
        {
            this.Email = newEmail;
            this.Password = newPassword;
        }
        
        //=========================================================================================================
        // Getters for derived classes
        //=========================================================================================================

        protected string GetEmail()
        {
            return this.Email;
        }

        protected string GetPassword()
        {
            return this.Password;
        }

        protected string GetFirstName()
        {
            return this.FirstName;
        }

        protected string GetLastName()
        {
            return this.LastName;
        }

        protected string GetID()
        {
            return this.ID;
        }
    }
}
