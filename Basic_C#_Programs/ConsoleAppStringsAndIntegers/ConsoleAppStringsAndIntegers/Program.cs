using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppStringsAndIntegers
{
    class Program
    {
        static void Main(string[] args)
        {

            // try and catch block for incorrect user input when dividing by 0 or by string
            // program prints useful message for user to display what has gone wrong.
            try
            {
                List<int> IntList = new List<int> { 46, 56, 25, 58, 25, 35, 67 };

                Console.WriteLine("Pick a number to divide each list element by.");
                int UserEntryDivNum = Convert.ToInt32(Console.ReadLine());
                // when 0 entered->System.DivideByZeroException: Attempted to divide by zero
                // when string entered->System.FormatException: Input string was not in a correct format. 
                foreach (int num in IntList)
                {

                    int Quotient = num / UserEntryDivNum;
                    Console.WriteLine("\n " + Quotient);
                }
            }catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            } 
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.WriteLine("You have emerged from a try catch block program will continue now.");
                Console.ReadLine();
            }



        }
    }
}
