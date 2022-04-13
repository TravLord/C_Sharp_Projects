using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsingEnumsConsoleApp
{
    class Program
    {
        enum DaysOfWeek
        {
            None,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
        static void Main(string[] args)
        {


            DaysOfWeek day;
            try
            {
                Console.WriteLine("Please enter the current day of the week.");
                string UserDayEntry = Console.ReadLine();
                day = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek),UserDayEntry);  //parsing user entry to see if values match in enum
            }
            catch (Exception ex)        // if values don't match print error message
            {
                Console.WriteLine("Failed.....Incorrect entry or format, please enter a day of the week starting with a capital letter.");
                Console.WriteLine(ex.Message);
                // this sets the fallback value of the day
                day = DaysOfWeek.None;
            } 
            // check to see if the conversion was successful 
           if (day == DaysOfWeek.Monday | day == DaysOfWeek.Tuesday | day == DaysOfWeek.Wednesday | day == DaysOfWeek.Thursday | day == DaysOfWeek.Friday | day == DaysOfWeek.Saturday | day == DaysOfWeek.Sunday)
            {
                Console.WriteLine("success");
            }

           
        }
    }
}
