using System;
using CV06.Entities.Interfaces;

namespace CV06.Entities
{
    class Cuboid : IObject3DBase
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }

        public Cuboid(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public void Draw()
        {
            Console.WriteLine($"Cuboid (height = {Height}; width = {Width}; length = {Length})");
        }

        public double GetSurfaceArea()
        {
            return 2 * (Height * Width + Height * Length + Length * Width);
        }

        public double GetVolume()
        {
            return Height * Width * Length;
        }
    }
}