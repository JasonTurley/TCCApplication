using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCApplication.Data
{
    // Data field for colleges and high schools
    public class SchoolData
    {
        public string CEEBCode;
        public string SchoolName;
        public string City;
        public string State;

        // Default properties are set to schools in Chicago, IL
        public SchoolData()
        {
            CEEBCode = "0";
            SchoolName = string.Empty;
            City = "Chicago";
            State = "IL";
        }

        public SchoolData(string name, string city, string state)
        {
            this.CEEBCode = GetCEEBCode();
            this.SchoolName = name;
            this.City = city;
            this.State = state;
        }

        // TODO: change me
        public string GetCEEBCode()
        {
            return "12345";
        }
    }
}
