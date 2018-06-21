using System;

namespace TCCApplication.Data
{
    public class RecData : PersonData
    {
        // Properties are set to test user "Helen Brown's" data by default
        public RecData()
        {
            Email = "Helen_Brown_alpha@mailinator.com";
            FirstName = "Helen_";
            LastName = "Brown_alpha";
            ID = "2420";
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