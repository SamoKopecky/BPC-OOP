using System;
using CV06.Entities.Bases;

namespace CV06.Entities
{
    class Rectangle : Object2DBase
    {
        public int Width { get; set; }
        public int Length { get; set; }

        public Rectangle(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public override void Draw()
        {
            Console.WriteLine($"Rectangle (width = {Width}; length = {Length})");
        }

        public override double GetArea()
        {
            return Width * Length;
        }
    }
}