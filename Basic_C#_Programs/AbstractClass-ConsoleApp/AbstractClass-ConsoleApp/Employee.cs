using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass_ConsoleApp
{
    public class Employee : Person
    {
        // employee class inherits person class and implements abstract method which is called in main program
        public override void sayName()
        {
            Console.WriteLine("Hello {0} {1} welcome to the abstract.", firstName, lastName);

        }
    }
}
