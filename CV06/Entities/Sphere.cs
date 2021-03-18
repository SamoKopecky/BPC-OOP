using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class Sphere : IObject3DBase
    {
        public int Radius { get; set; }

        public Sphere(int radius)
        {
            Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Sphere (radius = {Radius})");
        }

        public double GetSurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public double GetVolume()
        {
            return 4 / 3D * Math.PI * Math.Pow(Radius, 3);
        }
    }
}