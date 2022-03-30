using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingDimsAndQuoteApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Package Express!  Please follow the instructions below.");

            Console.WriteLine("Please enter the package weight?");
            string weightQ = Console.ReadLine();
            int weightConv = Convert.ToInt32(weightQ);

            if (weightConv > 50)
            {
                Console.WriteLine("Package too heavy to be shipped via Package Express.  Have a good day.");
            }
            else
                Console.WriteLine("What is the package width?");

            string widthQ = Console.ReadLine();
            int widthConv = Convert.ToInt32(widthQ);

            Console.WriteLine("What is the package height?");
            string heightQ = Console.ReadLine();
            int heightConv = Convert.ToInt32(heightQ);

            Console.WriteLine("What is the package length?");
            string lengthQ = Console.ReadLine();
            int lengthConv = Convert.ToInt32(lengthQ);

            int totalDims = lengthConv + heightConv + widthConv;

            decimal quoteDims = widthConv * heightConv * lengthConv;
            decimal quoteDimsWeight = quoteDims * weightConv;
            decimal quoteDimsTotal = quoteDimsWeight / 100.0000m;


            if (totalDims > 50)
            {
                Console.WriteLine("Package too big to be shipped via Package Express.");
            }
            else
                Console.WriteLine("Your estimated total for shipping this package is: " + "$" + quoteDimsTotal);

            Console.ReadLine();
        }
    }
}
