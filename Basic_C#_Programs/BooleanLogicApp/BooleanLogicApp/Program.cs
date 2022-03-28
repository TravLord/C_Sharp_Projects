using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooleanLogicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Questions to verfiy user inputted info to see if they qualify for insurance
            // Each questions input is converted to integers for proper boolean comparison

            Console.WriteLine("Personal Insurance qualifier");
            Console.WriteLine("What is your age?");
            string ageQ = Console.ReadLine();
            int ageQconv = Convert.ToInt32(ageQ);

            Console.WriteLine("How many DUI's do you have?");
            string duiQ = Console.ReadLine();
            int duiQconv = Convert.ToInt32(duiQ);


            Console.WriteLine("How many speeding tickets do you have?");
            string speedtikQ = Console.ReadLine();
            int speedTikQconv = Convert.ToInt32(speedtikQ);

            Console.WriteLine("Based off your answers, are you qualified? True or false?");

            // Age must be greater than 15
            bool qualifyAge = ageQconv > 15;

            // Must have 0 DUI's
            bool qualifyDuiQ = duiQconv < 1;

            // Must have less than 4 speeding tickets
            bool qualifySpeedTik = speedTikQconv < 4;

            // if all conditions (above) are met the user qualifies for insurance 
            Console.WriteLine(qualifyAge && qualifyDuiQ && qualifySpeedTik);
            Console.ReadLine();


        }
    }
}
