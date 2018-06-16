using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCCApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email: " + UserData.Email);
            Console.WriteLine("Password: " + UserData.Password);
            Console.ReadKey();
        }
    }
}
