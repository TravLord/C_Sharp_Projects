﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncomeComparisonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console app to calculate and compare user input salary info 

            //Person 1 (ask for info) convert data type and save info to variables
            Console.WriteLine("Anonymous Income Comparison Program");
            Console.WriteLine("Person 1");
            Console.WriteLine("\n Whats your hourly rate?");
            string hoursRate1 = Console.ReadLine();
            double hoursRateConv1 = Convert.ToDouble(hoursRate1);

            
            Console.WriteLine("How many hours do you work a week?");
            string hoursWeek1 = Console.ReadLine();
            int hoursWeekConv1 = Convert.ToInt32(hoursWeek1);

            //Person 2 (ask for info) convert data type and save info to variables
            Console.WriteLine("Person 2");
            Console.WriteLine("\n Whats your hourly rate?");
            string hoursRate2 = Console.ReadLine();
            double hoursRateConv2 = Convert.ToDouble(hoursRate2);


            Console.WriteLine("How many hours do you work a week?");
            string hoursWeek2 = Console.ReadLine();
            int hoursWeekConv2 = Convert.ToInt32(hoursWeek2);

            // Person 1 and 2 salary calculation - weekly and annual amounts
            double wkSalary1 = hoursRateConv1 * hoursWeekConv1;
            double annSalary1 = wkSalary1 * 52.18;
            Console.WriteLine("Annual salary of Person 1: \n"+ annSalary1);
            
            double wkSalary2 = hoursRateConv2 * hoursWeekConv2;
            double annSalary2 = wkSalary2 * 52.18;
            Console.WriteLine("Annual salary of Person 2: \n" + annSalary2);

            //Comparing person1 and person2 annual salary in boolean for true or false display
            bool annSalaryComp = annSalary1 > annSalary2;

            Console.WriteLine("Does Person 1 make more money than Person 2? \n" + annSalaryComp);

            








        }
    }
}
