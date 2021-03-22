using System;
using System.Collections.Generic;
using System.Text;

namespace CV07.Entities
{
    class Triangle : Object2DBase
    {
        public int Height { get; set; }
        public int SideLength { get; set; }

        public override double Area()
        {
            return (Height * SideLength) / 2D;
        }

        public override string ToString()
        {
            return $"Triangle (side length = {SideLength}; height = {Height})";
        }
    }
}