using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorChain_Const
{
    public class Animal
    {
        public Animal(string color):this(color, 4)
        {

        }
        public Animal(string color, int legsCount)
        {
            Color = color;
            LegsCount = legsCount;
            Console.WriteLine("Garfield!!!");

        }

        public string Color { get; set; }
        public int LegsCount { get; set; }



    }
}
