using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryCatchUserInputAge_ConsoleApp
{
    class Program  // This program takes the user input and subtracts it from the current date , then prints the new date to console
    {             // It also is wrapped in an if statement check for negative entries and a try and catch for all other possible thrown exceptions
                 // The while loop allows the user to return to the beginning of the question and enter a correct format
        static void Main(string[] args)        
                                                                                             
        {
            bool userInputIsValid = false;
            while (!userInputIsValid)
            {
                try
                {
                    Console.WriteLine("Hello there enter your age please .");
                    int UserInputInt = Convert.ToInt32(Console.ReadLine());
                    if (UserInputInt < 0)
                    {
                        userInputIsValid = false;
                        Console.WriteLine("No negative numbers! only enter digits 1-10. Please try again...");
                    }
                    else
                    {
                        DateTime currentDate = DateTime.Now;
                        DateTime NewDate = currentDate.AddYears(-UserInputInt); // This takes the user input and converts it to a negative number.  When you add the negative number to the datetime now object it subtracts that amount in years
                        Console.WriteLine("You were born in the year give or take a few hours ",NewDate);
                        userInputIsValid = true;
                    }                
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Incorrect format please only enter digits 1-10. Please try again...");
                    userInputIsValid = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    userInputIsValid = false;
                }               
            }
        }
    } 
}

