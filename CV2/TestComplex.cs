using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CV2
{
    public class TestComplex
    {
        public static Complex Expected { get; set; }
        public static Complex Actual { get; set; }
        public static string Name { get; set; }

        public static void Test()
        {
            if (Expected == Actual)
            {
                Console.WriteLine(Name + ": OK");
            }
            else
            {
                Console.WriteLine("Error: Expected value: " + Expected + " Actual value " + Actual);
            }
        }
    }
}