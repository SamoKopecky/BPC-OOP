using System;
using CV06.Entities.Bases;

namespace CV06.Entities
{
    class Cylinder : Object3DBase
    {
        public int Radius { get; set; }
        public int Height { get; set; }

        public Cylinder(int radius, int height)
        {
            Radius = radius;
            Height = height;
        }

        public override void Draw()
        {
            Console.WriteLine($"Cylinder (radius = {Radius}; height = {Height})");
        }

        public override double GetSurfaceArea()
        {
            return 2 * Math.PI * Radius * (Radius + Height);
        }

        public override double GetVolume()
        {
            return Math.PI * Math.Pow(Radius, 2) * Height;
        }
    }
}