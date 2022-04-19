using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorChain_Const
{
    class Program
    {
        static void Main(string[] args)
        {
            const string garfFaveFood = "Lasagna";
            var Fur = "orange";            
            Animal animal = new Animal(Fur);

            Console.WriteLine("Garfield the cat has {0} fur and {1} legs, his favorite food is {2}.",Fur, animal.LegsCount, garfFaveFood);
        }
    }
}
