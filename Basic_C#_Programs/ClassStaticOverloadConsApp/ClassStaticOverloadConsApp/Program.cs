using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStaticOverloadConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // User is asked to enter number, number is divided and displayed
            // to console without returning value to variable.

            Console.WriteLine("Please enter a number to be divided in half, then press enter.");
            int UserNum = Convert.ToInt32(Console.ReadLine());

            MathOperations mathOps = new MathOperations();
            mathOps.DivByTwo(UserNum);

            // this method call transfers value out of method with  output paramter and stores
            // result in OutVar variable overriding the value declared before call. 
            MathOperations mathOps1 = new MathOperations();
            int OutVar = 100;
            mathOps1.GetterParam(out OutVar);
            Console.WriteLine("After method is called get value --> {0}", OutVar);

            // This is an example of an overloaded method completed by user entry entered as string and converted to int
            Console.WriteLine("Please enter a number for an addition operation.");
            string UserEntryString = Console.ReadLine();
            MathOperations mathOps2 = new MathOperations();
            mathOps2.DivByTwo(UserEntryString);

            // static class method call dispalying response message
            ClassStatic.SimpleFunc();
            Console.ReadLine();

        }

    }
}
