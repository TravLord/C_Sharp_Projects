using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_DailyReport
{
    class Program    //Program to take in user input convert the
                     //data type and save data into a variable for further use
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your Name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello " + name);

            Console.WriteLine("What course are you on?");
            string course = Console.ReadLine();

            //converts string data type to integer for proper display and storage
            Console.WriteLine("What page number?");
            string pageNum = Console.ReadLine();
            int convPage = Convert.ToInt32(pageNum);


            //converts string data type to boolean for proper display and storage
            Console.WriteLine("Do you need any help with anything? Please answer true or false.");
            string needHelp = Console.ReadLine();
            bool convHelp = Convert.ToBoolean(needHelp);

            Console.WriteLine("Were there any positive experiences you'd like to share? \n Please give specifics.");
            string postiveExp = Console.ReadLine();

            Console.WriteLine("Is there any other feedback you'd like to provide? Please be \n specific.");
            string feedBack = Console.ReadLine();

            //converts string data type to decimal for proper display and storage
            Console.WriteLine("How many hours did you study today?");
            string hoursStudy = Console.ReadLine();
            decimal convHoursStudy = Convert.ToDecimal(hoursStudy);

            //End of program and message for user
            Console.WriteLine(" \"Thank you for your answers \n An instructor will respond to this shortly. Have a great \n day!\" This is the end of the program.");

        }
    }
}
