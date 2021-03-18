using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class Circle : IObject2D
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Circle (radius = {Radius})");
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}