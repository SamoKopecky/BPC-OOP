using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class Ellipse : IObject2D
    {
        public int SemiMinorAxis { get; set; }
        public int SemiMajorAxis { get; set; }

        public Ellipse(int semiMinorAxis, int semiMajorAxis)
        {
            SemiMinorAxis = semiMinorAxis;
            SemiMajorAxis = semiMajorAxis;
        }

        public void Draw()
        {
            Console.WriteLine($"Ellipse (semi-minor axis = {SemiMinorAxis}; semi-major axis = {SemiMajorAxis})");
        }

        public double GetArea()
        {
            return Math.PI * SemiMajorAxis * SemiMinorAxis;
        }
    }
}