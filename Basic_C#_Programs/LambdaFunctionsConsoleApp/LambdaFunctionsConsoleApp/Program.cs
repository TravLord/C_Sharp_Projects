using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFunctionsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiating new list and adding values including full name and id
            List<Employee> listEmployee = new List<Employee>();
            listEmployee.Add(new Employee { firstName = "Billy", lastName = "Madison", Id = 8 });
            listEmployee.Add(new Employee { firstName = "Chris", lastName = "Farely", Id = 2 });
            listEmployee.Add(new Employee { firstName = "Willy", lastName = "Wombat", Id = 1 });
            listEmployee.Add(new Employee { firstName = "Charles", lastName = "Manson", Id = 6 });
            listEmployee.Add(new Employee { firstName = "Lex", lastName = "Friedman", Id = 9 });
            listEmployee.Add(new Employee { firstName = "Bill", lastName = "Gates", Id = 10 });
            listEmployee.Add(new Employee { firstName = "Joe", lastName = "Shmoe", Id = 11 });
            listEmployee.Add(new Employee { firstName = "Travis", lastName = "Lordis", Id = 4 });
            listEmployee.Add(new Employee { firstName = "Joe", lastName = "Yo", Id = 12 });
            listEmployee.Add(new Employee { firstName = "NightHawk", lastName = "Dragon", Id = 3 });


            //finding all employees with the firstname joe in list using foreach and nested if loop
            //then adding each employee to a new list 
            List<Employee> JoeList = new List<Employee>();

            foreach (var worker in listEmployee)
            {
                if (worker.firstName == "Joe")
                {
                    
                    JoeList.Add(worker);
                    Console.WriteLine(worker.firstName);
                }

            }

            // using lambda function to complete the same function as the loops above
            List<Employee> newList = listEmployee.Where(x => x.firstName == "Joe").ToList();

            foreach (Employee employee in newList)
            {
                
                Console.WriteLine(employee.firstName);
            }

            // this lambda function finds all employees with an Id number greater than 5 
            // then adds them to list and prints to console
            List<Employee> EmpIdList = listEmployee.Where(y => y.Id > 5).ToList();

            foreach (Employee employee in EmpIdList)
            {
                
                Console.WriteLine(employee.Id);
            }

        }    
           
    }
}
