using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodClassConsoleApp
{
    class Program
    {  // app calling void method, won't return a value but can complete a task 
        static void Main()
        {
           
            firstOperateSecondDisplay OpDisplay = new firstOperateSecondDisplay();

            OpDisplay.OneOpTwoDisplay(2, 3);

            OpDisplay.OneOpTwoDisplay(Num1: 3, Num2: 2);

        }
    }
}
