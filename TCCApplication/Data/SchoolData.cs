using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCApplication.Data
{
    public class SchoolData
    {
        // Default values for searching for a school. Used when no arguments are given to SearchForSchool method 
        public static string SchoolName = "Illinois";
        public static string City = "Chicago";
        public static string State = "IL";

        public SchoolData()
        {
            SchoolName = string.Empty;
            City = string.Empty;
            State = string.Empty;
        }

        public SchoolData(string schoolName, string city, string state)
        {
            SchoolName = schoolName;
            City = city;
            State = state;
        }
    }
}
