using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_Objects_ConsoleApp
{                                   // Employee class inherits from person class 
    class Employee : Person
    {
        public int Id { get; set; }

        //overloaded operator used to check if employee id is equal to another employee
        public static bool operator== (Employee employee, Employee employee1)
        {
            bool equals = false;
            if (employee.Id == employee1.Id)
            {
                equals = true;
            }
            return equals;
        }
        
        // overloaded == requires a matching != overloaded operator in order to work properly
        public static bool operator!= (Employee employee, Employee employee1)
        {
            bool equals = false;
            if (employee.Id != employee1.Id)
            {
                equals = true;
            }
            return equals;
        }
        
    }
}
