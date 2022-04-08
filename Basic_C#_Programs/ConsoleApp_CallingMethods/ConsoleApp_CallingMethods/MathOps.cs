using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_CallingMethods
{
    public class MathOps
    // Created class with 3 methods each containing math operations
    // each called from main program when user gives input 
    { 
        public static int MultiplyUserEntry(int UserEntryNum)
        {
            int result = UserEntryNum * 95;
            return result;
        }

        public static int DivideUserEntry(int UserEntryNum)
        {
            int result = UserEntryNum / 6;
            return result;
        }

        public static int ModulusUserEntry(int UserEntryNum)
        {
            int result = UserEntryNum % 106;
            return result;
        }
    }
}

    

