using System;
using System.Collections.Generic;
using System.Text;

namespace CV07.Entities
{
    public class Square : Object2DBase
    {
        public int SideLength { get; set; }

        public override double Area()
        {
            return Math.Pow(SideLength, 2);
        }

        public override string ToString()
        {
            return $"Square (side length = {SideLength})";
        }
    }
}