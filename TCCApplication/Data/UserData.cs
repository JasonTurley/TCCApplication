﻿using System;

namespace TCCApplication.Data
{
    public class UserData : PersonData
    {

        public UserData()
        {
            Email = "jturley@commonapp.org";
            FirstName = "Jason";
            LastName = "Turley";
            Password = "C0mm0n@1-2";
            ID = "58354";

        }

        // Email and password required. The other fields can be updated later with UpdateInfo
        public UserData(string userEmail, string userPassword, string firstName, string lastName, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = userEmail;
            this.Password = userPassword;
            this.ID = id;
        }        

        public string GetPostalCode()
        {
            return "60103-1806";
        }

        public string GetCEEBCode()
        {
            return "142380";
        }
    }
}