using System;
using System.Collections.Generic;
using System.Linq;

namespace CV07.Entities
{
    public static class Extreme
    {
        public static T Maximum<T>(List<T> input) where T : IComparable
        {
            return input.Max();
        }

        public static T Minimum<T>(List<T> input) where T : IComparable
        {
            return input.Min();
        }
    }
}