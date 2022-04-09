using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOptionalMethodParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            // This console app will take in user input and perform math operation.  user can give one value or two values
            // and program will continue with default or user input depending on choice.

            OptionParams OpParams = new OptionParams();
            Console.WriteLine("Please enter a whole number for a math operation, then press enter. ");
            int firstEntryInt = Convert.ToInt32(Console.ReadLine());

            // second user entry tied to boolean to check if user input value if not input returns false
            Console.WriteLine("Enter a second number if you would like, then press enter..  This is not required.");
            var secondUserEntryIntIsValid = int.TryParse(Console.ReadLine(), out int secondEntryInt);

            // declare result variable to return value back after conditional state determined
            // if false boolean value only one parameter is given and default parameter value used
            // if both values given operation with user value executed

            int resultTwoInts;
            if (secondUserEntryIntIsValid)
            {
                resultTwoInts = OptionParams.twoInts(firstEntryInt, secondEntryInt);
            }
            else
            {
                resultTwoInts = OptionParams.twoInts(firstEntryInt);
            }
           
            Console.WriteLine("This is the result of a math operation --->{0}",resultTwoInts);
            Console.ReadLine();
        }
    }
}
