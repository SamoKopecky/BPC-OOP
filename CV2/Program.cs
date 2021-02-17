using System;
using System.Runtime.InteropServices;

namespace CV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new Complex(3, 2);
            var second = new Complex(1, -7);

            UseTest(first, second, new Complex(4, -5), "Addition", (a, b) => a + b);
            UseTest(first, second, new Complex(2, +9), "Subtraction", (a, b) => a - b);
            UseTest(first, second, new Complex(17, -19), "Division", (a, b) => a * b);
            UseTest(first, second, new Complex(-0.22, 0.46), "Multiplication", (a, b) => a / b);

            TestComplex.Expected = new Complex(-3, -2);
            TestComplex.Actual = -first;
            TestComplex.Name = "Negative";
            TestComplex.Test();

            TestComplex.Expected = new Complex(3, -2);
            TestComplex.Actual = first.Conjugate();
            TestComplex.Name = "Conjugate";
            TestComplex.Test();

            Console.WriteLine($"{first} != {second}: {first != second}");
            Console.WriteLine($"{first} == {new Complex(3, 2)}: {first == new Complex(3, 2)}");
            Console.WriteLine($"Modulus: {first.Modulus()}");
            Console.WriteLine($"Argument: {first.Argument()}");
        }

        private static void UseTest(Complex first, Complex second, Complex expected, string name,
            Func<Complex, Complex, Complex> operation)
        {
            TestComplex.Expected = expected;
            TestComplex.Actual = operation(first, second);
            TestComplex.Name = name;
            TestComplex.Test();
        }
    }
}