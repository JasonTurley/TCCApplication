using System;

namespace TCCApplication.Data
{
    public class UserData : PersonData
    {
        // As a bare minimum, all applicants need an email and password.
        // For the time being, use mine.
        public UserData()
        {
            Email = "jturley@commonapp.org";
            Password = "C0mm0n@1-2";
        }

        // Email and password required. The other fields can be updated later with UpdateInfo
        public UserData(string userEmail, string userPassword, string firstName = "", string lastName = "", string id = "")
        {
            this.Email = userEmail;
            this.Password = userPassword;
        }

        
    }
}