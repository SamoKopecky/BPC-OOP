using System;
using System.Collections.Generic;
using System.Linq;
using CV07.Entities;

namespace CV07
{
    class Program
    {
        public static void Main(string[] args)
        {
            var integers = new List<int> {1, 3, 5, 7, 9};
            var strings = new List<string> {"f", "z", "ag", "a", "test"};
            var circles = new List<Circle>
            {
                new Circle {Radius = 7},
                new Circle {Radius = 6},
                new Circle {Radius = 2},
                new Circle {Radius = 9},
                new Circle {Radius = 3}
            };
            var rectangles = new List<Rectangle>
            {
                new Rectangle {Width = 1, Length = 1},
                new Rectangle {Width = 7, Length = 4},
                new Rectangle {Width = 1, Length = 4},
                new Rectangle {Width = 5, Length = 9},
                new Rectangle {Width = 2, Length = 3}
            };
            var triangles = new List<Triangle>
            {
                new Triangle {Height = 3, SideLength = 8},
                new Triangle {Height = 7, SideLength = 4},
                new Triangle {Height = 1, SideLength = 4},
                new Triangle {Height = 5, SideLength = 9},
                new Triangle {Height = 2, SideLength = 3}
            };
            var squares = new List<Square>
            {
                new Square {SideLength = 7},
                new Square {SideLength = 6},
                new Square {SideLength = 2},
                new Square {SideLength = 9},
                new Square {SideLength = 3}
            };
            var bases = new List<IComparable>();
            bases.AddRange(squares);
            bases.AddRange(triangles);
            PrintList(bases);
            PrintList(squares);
            PrintList(triangles);
            PrintList(rectangles);
            PrintList(circles);
            PrintList(integers);
            PrintList(strings);
            Console.Write($"Filtered integers: {string.Join(", ", integers.Where(i => i >= 4 && i <= 8).ToList())}");
        }

        private static void PrintList<T>(List<T> list) where T : IComparable
        {
            Console.WriteLine($"Max: {Extreme.Maximum(list)}");
            Console.WriteLine($"Min: {Extreme.Minimum(list)}");
            foreach (var item in list)
            {
                Console.WriteLine($"\t{item}");
            }

            Console.WriteLine("======================================================");
        }
    }
}