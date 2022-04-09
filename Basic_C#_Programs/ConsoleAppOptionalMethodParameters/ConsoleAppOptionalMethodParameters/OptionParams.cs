using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppOptionalMethodParameters
{
    public class OptionParams
    {
        public static int twoInts(int firstUserEntryInt, int secondUserEntryInt = 1)
        {
            
            int result = firstUserEntryInt + secondUserEntryInt;
            return result;
        }

        

    }
}
