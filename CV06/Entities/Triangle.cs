using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class Triangle : IObject2D
    {
        public int SideLength { get; set; }
        public int Height { get; set; }

        public Triangle(int sideLength, int height)
        {
            SideLength = sideLength;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Triangle (side length = {SideLength}; height = {Height})");
        }

        public double GetArea()
        {
            return (SideLength * Height) / 2D;
        }
    }
}