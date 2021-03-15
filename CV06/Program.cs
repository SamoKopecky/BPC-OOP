using System;
using System.Runtime.InteropServices;
using CV06.Entities;

namespace CV06
{
    class Program
    {
        private static void Main(string[] args)
        {
            double areaSum = 0;
            double surfaceAreaSum = 0;
            double volumeSum = 0;
            GraphicObjectBase[] graphicObjects =
            {
                new Circle(5),
                new Cuboid(5, 6, 7),
                new Cylinder(5, 5),
                new Ellipse(5, 7),
                new Rectangle(5, 6),
                new Sphere(5),
                new SquarePyramid(5, 5),
                new Triangle(5, 5)
            };
            foreach (var graphicObject in graphicObjects)
            {
                graphicObject.Draw();

                if (graphicObject is Object2DBase object2D)
                {
                    var area = object2D.GetArea();
                    Console.WriteLine($"\tArea: {area:F2}");
                    areaSum += area;
                }

                if (graphicObject is Object3DBase object3D)
                {
                    var surfaceArea = object3D.GetSurfaceArea();
                    var volume = object3D.GetVolume();
                    Console.WriteLine($"\tSurface Area: {surfaceArea:F2}, Volume: {volume:F2}");
                    surfaceAreaSum += surfaceArea;
                    volumeSum += volume;
                }

                Console.WriteLine("------------------------------------------------------------------");
            }

            Console.WriteLine($"Total area: {areaSum:F2}");
            Console.WriteLine($"Total surface area: {surfaceAreaSum:F2}");
            Console.WriteLine($"Total volume: {volumeSum:F2}");
        }
    }
}