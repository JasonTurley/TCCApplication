using System;

namespace TCCApplication.Data
{
    public class AppData
    {
        //TODO: change hard coded values
        public static string Email = "jturley@commonapp.org";
        public static string Password = "C0mm0n@1-2";
        public static string FirstName = "Jason";
        public static string LastName = "Turley";

        public AppData()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public AppData(string userEmail, string userPassword)
        {
            Email = userEmail;
            Password = userPassword;
        }
    }
}