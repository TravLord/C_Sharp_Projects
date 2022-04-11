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
            Employee employee = new Employee() { FirstName = "Sample", LastName = "Student" };
            employee.SayName();


        }
    }
}
