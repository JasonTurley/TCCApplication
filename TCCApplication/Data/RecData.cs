using System;

namespace TCCApplication.Data
{
    public class RecData
    {
        // TODO: change hard coded values
        public static string Email = "Helen_Brown_alpha@mailinator.com";
        public static string FirstName = "Helen_";
        public static string LastName = "Brown_alpha";
        public static string ID = "2420";

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
