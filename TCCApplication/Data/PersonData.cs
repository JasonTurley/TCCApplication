using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCApplication.Data
{
    public class PersonData
    {
        protected string FirstName;
        protected string LastName;
        protected string Email;
        protected string Password;
        protected string ID;

        public static string defaultFirstName = "Blah";
        public static string defaultLastName = "Lol";
        public static string defaultEmail = "default-email@mailinator.com";
        public static string defaultPassword = "$default-password1234";

        // Default constructor. Sets properties to junk default values
        public PersonData()
        {
            FirstName = defaultFirstName;
            LastName = defaultLastName;
            Email = defaultEmail;
            Password = defaultPassword;
            ID = "123456";
        }

        public PersonData(string firstName, string lastName, string email, string password, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.ID = id;
        }

        public void UpdateName(string newFirstName, string newLastName)
        {
            this.FirstName = newFirstName;
            this.LastName = newLastName;
        }

        public void UpdateLoginInfo(string newEmail, string newPassword)
        {
            this.Email = newEmail;
            this.Password = newPassword;
        }
    }
}
