using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass_ConsoleApp
{
    public abstract class Person    //abstract class with 2 properties 1 method
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        // abstract method implemented in inheriting class employee
        public abstract void sayName();
    }
}
