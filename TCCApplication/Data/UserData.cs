using System;

namespace TCCApplication
{
    public class UserData
    {

        /// <summary>
        /// Required login information
        /// </summary>
        public static string Email = "jturley@commonapp.org";

        public static string Password = "C0mm0n@1-2";

        public UserData()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public UserData(string userEmail, string userPassword)
        {
            Email = userEmail;
            Password = userPassword;
        }
    }
}