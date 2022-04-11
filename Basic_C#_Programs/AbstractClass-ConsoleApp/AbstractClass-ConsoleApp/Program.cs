using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // intializing employee object with values and calling abstract method sayName to display to console
            Employee employee = new Employee() { firstName = "Sample", lastName = "Student" };
            employee.sayName();
        }
    }
}
