using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodConsoleApp
{
    class Program
    {                                   // object instantiation before each method call
                                        // passing in int first decimal second and string third
        static void Main()                  
        {
            Operations Ops = new Operations();
            int Sum = Operations.Addition(875);

            Console.WriteLine("The Addition method sum is: {0} ",Sum);
            Console.ReadLine();

            Operations DecimalOps = new Operations();
            decimal Num1decimaltoInt = Operations.Addition(307.5m);

            Console.WriteLine("The overloaded addition method sum is: {0} ", Num1decimaltoInt);
            Console.ReadLine();

            Operations StringNumOps = new Operations();
            
            int InputString = Operations.Addition("96");
            Console.WriteLine("Here's that string back as an integer --> {0}", InputString);
            Console.ReadLine();
            
        }        
    }
}
