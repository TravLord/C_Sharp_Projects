using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStaticOverloadConsApp
{
    public class MathOperations
    {
        public MathOperations()
        {
           
        }

        // This method displays the user entry number divided by 2 but doesn't return anything
        public void DivByTwo(int UserNum)
        {
            int QuotientResult = UserNum / 2;
            Console.WriteLine("Your entry divided by two is {0}", QuotientResult);
        }

        // This method has output parameters transferring data out of it rather then in.
        public void GetterParam( out int set)
        {
            int tempVar = 77;
            set = tempVar;
        }

        // this is an overloaded method of the DivByTwo method above
        // in this case it takes a string then converts it for math operation result display

        public void DivByTwo(string UserEntryString)
        {
          int UserEntryStringConv = Convert.ToInt32(UserEntryString);
            int result = UserEntryStringConv + 97;
            Console.WriteLine("Your entry plus 97 is --> {0}", result);
        }

        
    }
}
