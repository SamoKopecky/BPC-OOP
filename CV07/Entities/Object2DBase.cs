using System;
using System.Collections.Generic;
using System.Text;
using CV07.Interfaces;

namespace CV07.Entities
{
    public abstract class Object2DBase : IObject2D, IComparable
    {
        public abstract double Area();


        public int CompareTo(Object obj)
        {
            var otherObject = obj as Object2DBase;
            if (otherObject == null) return 0;
            return Area().CompareTo(otherObject.Area());
        }
    }
}