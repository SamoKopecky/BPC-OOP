using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV07.Entities
{
    public static class Extreme
    {
        public static T Maximum<T>(List<T> input) where T : IComparable
        {
            // To not sort the original collection
            var tempList = input.ToList();
            tempList.Sort();
            return tempList.Last();
        }

        public static T Minimum<T>(List<T> input) where T : IComparable
        {
            // To not sort the original collection
            var tempList = input.ToList();
            tempList.Sort();
            return tempList.First();
        }
    }
}