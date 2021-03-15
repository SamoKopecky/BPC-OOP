using System;
using CV06.Entities.Bases;

namespace CV06.Entities
{
    class Triangle : Object2DBase
    {
        public int SideLength { get; set; }
        public int Height { get; set; }

        public Triangle(int sideLength, int height)
        {
            SideLength = sideLength;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Triangle (side length = {SideLength}; height = {Height})");
        }

        public override double GetArea()
        {
            return (SideLength * Height) / 2D;
        }
    }
}