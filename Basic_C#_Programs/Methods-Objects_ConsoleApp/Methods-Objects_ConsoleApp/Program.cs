using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Objects_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //employee initialization of object utilizing person classes method from inheritance
            //Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };
            //employee.SayName();

            Employee employee = new Employee();
            Employee employee1 = new Employee();
            employee.Id = 1;
            employee1.Id = 2;

            bool EmployeeEquals = employee == employee1;
            Console.WriteLine(EmployeeEquals); // result of overloaded operator




        }
    }
}
