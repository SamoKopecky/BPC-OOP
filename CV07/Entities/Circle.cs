using System;

namespace CV07.Entities
{
    public class Circle : Object2DBase
    {
        public int Radius { get; set; }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return $"Circle (radius = {Radius})";
        }
    }
}