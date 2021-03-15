using System;
using System.Collections.Generic;
using System.Text;

namespace CV06.Entities
{
    class Ellipse : Object2DBase
    {
        public int SemiMinorAxis { get; set; }
        public int SemiMajorAxis { get; set; }

        public Ellipse(int semiMinorAxis, int semiMajorAxis)
        {
            SemiMinorAxis = semiMinorAxis;
            SemiMajorAxis = semiMajorAxis;
        }

        public override void Draw()
        {
            Console.WriteLine($"Ellipse (semi-minor axis = {SemiMinorAxis}; semi-major axis = {SemiMajorAxis})");
        }

        public override double GetArea()
        {
            return Math.PI * SemiMajorAxis * SemiMinorAxis;
        }
    }
}