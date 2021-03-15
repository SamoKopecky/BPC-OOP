using System;
using CV06.Entities.Bases;

namespace CV06.Entities
{
    class Sphere : Object3DBase
    {
        public int Radius { get; set; }

        public Sphere(int radius)
        {
            Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Sphere (radius = {Radius})");
        }

        public override double GetSurfaceArea()
        {
            return 4 * Math.PI * Math.Pow(Radius, 2);
        }

        public override double GetVolume()
        {
            return 4 / 3D * Math.PI * Math.Pow(Radius, 3);
        }
    }
}