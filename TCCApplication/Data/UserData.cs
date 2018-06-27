using System;

namespace TCCApplication.Data
{
    public class UserData : PersonData
    {

        public UserData()
        {
            FirstName = "Jason";
            LastName = "Turley";
            Email = "jturley@commonapp.org";
            Password = "C0mm0n@1-2";
        }

        // Email and password fields are required. The others can be updated later with the UpdateInfo method
        public UserData(string userEmail, string userPassword, string firstName = "", string lastName = "", string id = "")
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = userEmail;
            this.Password = userPassword;
            this.ID = id;
        }        
    }
}