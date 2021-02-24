using System;
using System.Runtime.InteropServices;

namespace CV03
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Matrix(new double[,]
            {
                {1, 2, 3, 5},
                {4, 5, 6, 7}
            });
            var b = new Matrix(new double[,]
            {
                {1, 4, 8},
                {2, 5, 9},
                {3, 6, 3},
                {7, 8, 1}
            });
            var c = new Matrix(new double[,]
            {
                {5, 9, 7, 1},
                {8, 2, 6, 4}
            });
            var cCopy = new Matrix(new double[,]
            {
                {5, 9, 7, 1},
                {8, 2, 6, 4}
            });
            var d = new Matrix(new double[,]
            {
                {1, 6, 3},
                {6, 5, 2},
                {7, 3, 9}
            });
            var e = new Matrix(new double[,]
            {
                {3, 7},
                {2, 4}
            });

            try
            {   // Uncomment to test error states.
                //var temp = a + b;
                //var temp = a - b;
                //var temp = a * c;
                //var temp = c.Determinant();
                Console.WriteLine($"a + c = \n{a + c}");
                Console.WriteLine($"a - c = \n{a - c}");
                Console.WriteLine($"a * b = \n{a * b}");
                Console.WriteLine($"c == cCopy = {c == cCopy}\n");
                Console.WriteLine($"c == a = {c == a}\n");
                Console.WriteLine($"c != cCopy = {c != cCopy}\n");
                Console.WriteLine($"c != a = {c != a}\n");
                Console.WriteLine($"-a = \n{-a}");
                Console.WriteLine($"Determinant of d: {d.Determinant()}");
                Console.WriteLine($"Determinant of e: {e.Determinant()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}