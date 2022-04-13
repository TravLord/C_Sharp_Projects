using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //instantiating struct object and assigning val then printing to console
            Number number = new Number() { Amount = 45.5m };
            Console.WriteLine(number.Amount);
            

          
        }
    }
}
