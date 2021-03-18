using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class Rectangle : IObject2DBase
    {
        public int Width { get; set; }
        public int Length { get; set; }

        public Rectangle(int width, int length)
        {
            Width = width;
            Length = length;
        }

        public void Draw()
        {
            Console.WriteLine($"Rectangle (width = {Width}; length = {Length})");
        }

        public double GetArea()
        {
            return Width * Length;
        }
    }
}