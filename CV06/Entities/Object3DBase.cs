using System;
using System.Collections.Generic;
using System.Text;

namespace CV06.Entities
{
    abstract class Object3DBase : GraphicObjectBase
    {
        public abstract double GetSurfaceArea();
        public abstract double GetVolume();
    }
}