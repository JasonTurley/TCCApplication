using System;

namespace TCCApplication.Data
{
    public class RecData
    {
        public static string Email;
        public static string FirstName;
        public static string LastName;
        public static string ID;

        public RecData()
        {
            Email = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            ID = string.Empty;
        }

        public RecData(string email, string firstName = "", string lastName = "", string id = "")
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            ID = id;
        }
    }
}
