using System;
using static System.Console;

namespace Test_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string s in Enum.GetNames(typeof(Type)))
                WriteLine(s);
            WriteLine();

        }
    }
}
