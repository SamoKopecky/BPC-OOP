using System;
using CV07.Interfaces;

namespace CV07.Entities
{
    public abstract class Object2DBase : IObject2D, IComparable
    {
        public abstract double Area();


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            if (obj is Object2DBase otherObject)
            {
                return Area().CompareTo(otherObject.Area());
            }

            return 1;
        }
    }
}