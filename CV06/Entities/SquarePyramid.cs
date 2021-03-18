using System;
using CV06.Interfaces;

namespace CV06.Entities
{
    class SquarePyramid : IObject3DBase
    {
        public int SideLength { get; set; }
        public int Height { get; set; }

        public SquarePyramid(int sideLength, int height)
        {
            SideLength = sideLength;
            Height = height;
        }

        public void Draw()
        {
            Console.WriteLine($"Square pyramid (side length = {SideLength}; height = {Height})");
        }

        public double GetSurfaceArea()
        {
            var cornerHeight = Math.Sqrt(Math.Pow(Math.Sqrt(2) * SideLength / 2, 2) + Math.Pow(Height, 2));
            var sideHeight = Math.Sqrt(Math.Pow(cornerHeight, 2) - Math.Pow(SideLength / 2D, 2));
            var sideArea = SideLength * sideHeight / 2D;
            return Math.Pow(SideLength, 2) + 4 * sideArea;
        }

        public double GetVolume()
        {
            return 1 / 3D * Math.Pow(SideLength, 2) * Height;
        }
    }
}