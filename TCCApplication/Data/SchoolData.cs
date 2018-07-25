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
        private string CeebCode;
        private string Name;
        private string City;
        private string State;

        // Default properties are set to schools in Chicago, IL
        public SchoolData()
        {
<<<<<<< HEAD
            CeebCode = string.Empty;
            SchoolName = string.Empty;
=======
            CeebCode = "0";
            Name = string.Empty;
>>>>>>> refactor
            City = "Chicago";
            State = "IL";
        }

        public SchoolData(string code, string name, string city, string state)
        {
            this.CeebCode = code;
            this.Name = name;
            this.City = city;
            this.State = state;
        }

        //=========================================================================================================
        // Getters
        //=========================================================================================================

        public string GetCEEBCode()
        {
            // FIXME
            return "";
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetCity()
        {
            return this.City;
        }

        public string GetState()
        {
            return this.State;
        }
    }
}
