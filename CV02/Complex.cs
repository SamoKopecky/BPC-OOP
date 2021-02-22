using System;

namespace CV2
{
    public class Complex
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        private static double Epsilon = 1E-6;

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static Complex operator +(Complex a, Complex b) =>
            new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);

        public static Complex operator -(Complex a, Complex b) =>
            new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);

        public static Complex operator -(Complex a) =>
            new Complex(-a.Real, -a.Imaginary);

        public static Complex operator *(Complex a, Complex b)
        {
            var real = (a.Real * b.Real) - (a.Imaginary * b.Imaginary);
            var imaginary = (a.Real * b.Imaginary) + (a.Imaginary * b.Real);
            return new Complex(real, imaginary);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            var divisor = Math.Pow(b.Real, 2) - (b.Imaginary * (-b.Imaginary));
            var real = (a.Real * b.Real) - (a.Imaginary * -b.Imaginary);
            var imaginary = (a.Real * -b.Imaginary) + (a.Imaginary * b.Real);
            return new Complex(real / divisor, imaginary / divisor);
        }


        public static bool operator ==(Complex a, Complex b)
        {
            return (Math.Abs(a.Real - b.Real) < Epsilon) && (Math.Abs(a.Imaginary - b.Imaginary) < Epsilon);
        }


        public static bool operator !=(Complex a, Complex b)
        {
            return (Math.Abs(a.Real - b.Real) >= Epsilon) || (Math.Abs(a.Imaginary - b.Imaginary) >= Epsilon);
        }

        public double Modulus() => Math.Sqrt(Math.Pow(Real, 2) + Math.Pow(Imaginary, 2));

        public double Argument() => Math.Atan2(Imaginary, Real);

        public Complex Conjugate() => new Complex(Real, -Imaginary);


        public override string ToString()
        {
            if (Imaginary < 0)
            {
                return $"{Real}{Imaginary}j";
            }

            return $"{Real}+{Imaginary}j";
        }
    }
}