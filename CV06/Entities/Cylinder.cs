using System;
using CV06.Entities.Interfaces;

namespace CV06.Entities
{
    class Cylinder : IObject3DBase
    {
        public int Radius { get; set; }
        public int Height { get; set; }

        public Cylinder(int radius, int height)
        {
            Radius = radius;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Cylinder (radius = {Radius}; height = {Height})");
        }

        public double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * (Radius + Height);
        }

        public double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
    }
}