﻿using System;
using CV06.Entities.Bases;

namespace CV06.Entities
{
    class Circle : Object2DBase
    {
        public int Radius { get; set; }

        public Circle(int radius)
        {
            Radius = radius;
        }

        public override void Draw()
        {
            Console.WriteLine($"Circle (radius = {Radius})");
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}