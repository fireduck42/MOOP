using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2
{
    public class Person
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public static void GetALastName(out string lastName)
        {
            lastName = "Otze";
        }

        public static void GetAFirstName(out string firstName)
        {
            firstName = "Jan-Pillemann";
        }
    }
}
