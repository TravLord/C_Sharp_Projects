using System;

namespace MyConsoleProject.cs
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("what is your name?");
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name + "!");
            Console.Read();
        }
    }
}
