using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino
{
    public class FraudException : Exception
    {
        public FraudException()
            : base() { }               // Creating two constructors one overloading the other , having them implement the exact same implementation that exists for exceptions
        public FraudException(string message)
            : base(message) { }
    }
}
