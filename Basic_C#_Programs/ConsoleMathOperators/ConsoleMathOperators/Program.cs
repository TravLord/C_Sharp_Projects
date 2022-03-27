using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMathOperators
{
    class Program
    {
        static void Main(string[] args)
        {

            //user input multiplied by 50 prints result
            Console.WriteLine("Please enter a number to be multiplied by 50: ");
            string fiftyX = Console.ReadLine();
            long convX = Convert.ToInt64(fiftyX);
            long xResult = 50 * convX;
            Console.WriteLine(xResult);

            //user input added by 25 prints result
            Console.WriteLine(" Please enter a number to add 25 to: ");
            string Add25 = Console.ReadLine();
            int convAdd25 = Convert.ToInt32(Add25);
            int add25result = 25 + convAdd25;
            Console.WriteLine(add25result);

            //user input divided by 12.5 prints result
            Console.WriteLine(" Please enter a number to divide by 12.5: ");
            string Div12 = Console.ReadLine();
            double convDiv12 = Convert.ToDouble(Div12);
            double div12result = convDiv12 / 12.5;
            Console.WriteLine(div12result);

            //user input checks if number is greater than 50 prints result
            Console.WriteLine(" Please enter a number to check if value greater than 50: ");
            string Grt50 = Console.ReadLine();
            int convGrt50 = Convert.ToInt32(Grt50);
            bool resultComp50 = convGrt50 > 50;
            Console.WriteLine(resultComp50);

            //user input divides by 7 and prints remainder
            Console.WriteLine(" Please enter a number to divide by seven \n The remainder will be displayed: ");
            string mod7 = Console.ReadLine();
            int convMod7 = Convert.ToInt32(mod7);
            int remainMod7 = convMod7 % 7;
            Console.WriteLine(remainMod7);


        }
    }
}
