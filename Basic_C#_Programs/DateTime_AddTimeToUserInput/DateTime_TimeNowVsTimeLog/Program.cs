using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTime_TimeNowVsTimeLog
{
    class Program
    {
        static void Main(string[] args)
        {
            //printing current time to console upon opening console
            Console.WriteLine(DateTime.Now);
            //asking user for a number  
            Console.WriteLine("Type in a number please..... and we will see what time it will be in that amount of hours");
            string UserEntry = Console.ReadLine();
            // convert user entry into a double for proper addition
            double UserEntryDouble = Convert.ToDouble(UserEntry);
            //saving the exact time into a variable for use below
            DateTime currentTime = DateTime.Now;


            // adding the user entry time with the current time and printing to console
            DateTime UserEntryHourDiff = currentTime.AddHours(UserEntryDouble); 
            Console.WriteLine("Your entry converted to hours and added to the exact current time is: \n{0}", UserEntryHourDiff);
            Console.ReadLine();
            
        }
    }
}
