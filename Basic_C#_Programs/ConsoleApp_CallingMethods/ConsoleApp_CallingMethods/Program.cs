using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CallingMethods
{
     class Program
    {
        static void Main()
        {
            // Simple program that asks for a number and returns result to the console after
            // some math operations are applied to it.

            Console.WriteLine("What number do you want to do math operations on?");
            string UserEntry = Console.ReadLine();
            int UserEntryNum = Convert.ToInt32(UserEntry);

            //Calling 3 class methods one by one and printing result of methods to console

            MathOps.MultiplyUserEntry(UserEntryNum);
            int resultMultiply = MathOps.MultiplyUserEntry(UserEntryNum);
            Console.WriteLine("\nThis is the result of multiplying your entry by 95 --> " + resultMultiply);



            MathOps.DivideUserEntry(UserEntryNum);
            int resultDivide = MathOps.DivideUserEntry(UserEntryNum);
            Console.WriteLine("\nThis is the result of dividing your entry by 6 --> " + resultDivide);


            MathOps.ModulusUserEntry(UserEntryNum);
            int resultModulus = MathOps.ModulusUserEntry(UserEntryNum);
            Console.WriteLine("\nThis is the remainder of dividing your entry by 106 --> " + resultModulus);

        }      
    }
}
