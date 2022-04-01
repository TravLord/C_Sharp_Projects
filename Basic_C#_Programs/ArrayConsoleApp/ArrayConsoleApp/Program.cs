using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // initializing boolean and do while loop for restarting program and ending program capability
            // when incorrect input entered by user
            bool restart = false;
            do
            {
                // User input console app- user chooses number which accesses a index value in a string array and displays result to console
                Console.WriteLine("Select an random number between 0-5 to display your daily positive affirmation.");
                string InxSelectStr = Console.ReadLine();
                int InxSelectConv = Convert.ToInt32(InxSelectStr);


                // String array instantiation
                string[] StringArray ={ "You are worth it!","You got this!","Sweat today don't regret today!",
                                    "Its a new day, get back up and try again!","You deserve to learn and grow!",
                                    "Research, Isolate, integrate, review, change, repeat."};


                //Prints to console the user selected string (converted to int)
                // If input incorrect corresponding message given while program is restarted
                // If correct program flow continues to next question
                if (InxSelectConv > 5 )
                {
                    Console.WriteLine("Incorrect choice, must be a number between 0 and 5");
                    restart = true;
                    
                }
                else
                {
                    restart = false;
                    Console.WriteLine(StringArray[InxSelectConv]);

                }

                
                // another user selection to display selected index and data to console
                Console.WriteLine("Please choose 0-5 to display your future salary prediction.");
                string SalInxSelect = Console.ReadLine();
                int SalInxConv = Convert.ToInt32(SalInxSelect);


                double[] SalPredArray = { 87500.00, 100000.00, 93000.00, 80000.00, 110000.00, 77000.00 };

                if (SalInxConv > 5)
                {
                    Console.WriteLine("Incorrect choice, must be a number between 0 and 5");
                    restart = true;
                }
                else
                {
                    Console.WriteLine("$" + SalPredArray[SalInxConv]);
                    
                }
                // user selection of list index prints to console or prints error message and restarts program
                Console.WriteLine("Please choose 0-5 for your daily mood prediction.");
                string MoodIndSelect = Console.ReadLine();
                int MoodIndConv = Convert.ToInt32(MoodIndSelect);

                List<string> StringyListy = new List<string>();
                StringyListy.Add("Annoyed");
                StringyListy.Add("Appreciative");
                StringyListy.Add("Grateful");
                StringyListy.Add("Happy");
                StringyListy.Add("Cranky");
                StringyListy.Add("Sad");

                if (SalInxConv > 5)
                {
                    Console.WriteLine("Incorrect choice, must be a number between 0 and 5");
                    restart = true;
                }
                else
                {
                    Console.WriteLine( StringyListy[MoodIndConv]);
                    Console.WriteLine("Have a nice day!");
                }

            } while (restart);
        }
    }
}
            
            
                
                
            



            

            ////Prints to console the user selected string (converted to int)
            //if (InxSelectConv < 5)
            //{
            //    Console.WriteLine(StringArray[InxSelectConv]);
            //}
            //else
            //{
            //    Console.WriteLine("Incorrect choice, must be a number between 0 and 5");

            //}

            // Concatenation for better display 




        
