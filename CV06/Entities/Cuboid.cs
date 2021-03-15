using System;
using System.Collections.Generic;
using System.Text;

namespace CV06.Entities
{
    class Cuboid : Object3DBase
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

        public override void Draw()
        {
            Console.WriteLine($"Cuboid (height = {Height}; width = {Width}; length = {Length})");
        }

        public override double GetSurfaceArea()
        {
            return 2 * (Height * Width + Height * Length + Length * Width);
        }

        public override double GetVolume()
        {
            return Height * Width * Length;
        }
    }
}
