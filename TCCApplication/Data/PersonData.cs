/// <summary>
/// PersonData.cs - Abstract class. 
/// </summary>
namespace TCCApplication.Data
{
    // Base class for Applicants and Recommenders
    public class PersonData
    {
        public string FirstName;
        public string LastName;
        public string Email;
        public string Password;
        public string ID;

        public PersonData()
        {

        }

        public PersonData(string firstName, string lastName, string email, string password, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.ID = id;
        }

        public void UpdateInfo(string newFirstName, string newLastName, string id = "")
        {
            this.FirstName = newFirstName;
            this.LastName = newLastName;
            this.ID = id;
        }

        public void UpdateLoginInfo(string newEmail, string newPassword)
        {
            this.Email = newEmail;
            this.Password = newPassword;
        }
        
        //=========================================================================================================
        // Getters for derived classes
        //=========================================================================================================

        public string GetEmail()
        {
            return this.Email;
        }

        public string GetPassword()
        {
            return this.Password;
        }

        public string GetFirstName()
        {
            return this.FirstName;
        }

        public string GetLastName()
        {
            return this.LastName;
        }

        public string GetID()
        {
            return this.ID;
        }
    }
}
