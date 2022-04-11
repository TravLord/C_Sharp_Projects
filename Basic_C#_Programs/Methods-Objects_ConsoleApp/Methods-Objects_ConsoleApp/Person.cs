using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Objects_ConsoleApp
{
    public class Person
    {
        // two properties for name of person
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // one method to print properties accessable from Employee class
        public void SayName()
        {
            Console.WriteLine(FirstName + " " + LastName);
        }
    }
}
