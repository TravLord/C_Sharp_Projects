using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainMethodConsoleApp
{
    public class Operations      // This class contains 3 methods with identical
                                 // name with 3 different overload parameters
                                 // this allows many different data type
                                 // inputs to be made and will
                                 // still return a valid answer            
    {
        public Operations()
        {

        }     
            //first addition method take in int and return answer as int
            public static int Addition(int Num1)
            {
                int Sum = Num1 + 1134;
                return Sum;
            }
        // second additon method with decimal parameter takes in decimal
        // converts it to int after operation done
        public static int Addition(decimal Num1decimal)
        {
           decimal SumDecimal = Num1decimal + 400.75m;
            return Convert.ToInt32(SumDecimal);
        }
        // third addition method with string parameter, takes in string converts it to int
        // then does math operation and returns int
        public static int Addition(string NumString)
        {           
            int NumStringToInt = Convert.ToInt32(NumString);
            int NumStringConv1Result = NumStringToInt / 6;           
            return NumStringConv1Result;                     
        }
               
    }
    
}




