using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_DoWhileStmt
{
    class Program
    {
        static void Main(string[] args)

        {
            // boolean while and do while loop console app
            // Asks user a question and input starts while loop with corresponding response
            Console.WriteLine("Wanna fight? please answer true or false.");
            String CanUfight = Console.ReadLine();
            bool CanFightConv = Convert.ToBoolean(CanUfight);

            while (CanFightConv == true)
            {
                Console.WriteLine("Okay fisticuffs it is!");
                break;
            }
            while (CanFightConv == false)
            {
                Console.WriteLine("Okay we'll hug instead...");
                break;
            }
            

            // asks user if they are human and prints response if answer is true
            Console.WriteLine("Are you human? Please answer true or false.");
            string Uname =Console.ReadLine();
            bool UnameConv = Convert.ToBoolean(Uname);
            if (UnameConv == true)
            {
                do
                {
                    Console.WriteLine("Hi there human!");
                    break;
                }
                while (UnameConv == true);
                
            }             
        }
    }
}
