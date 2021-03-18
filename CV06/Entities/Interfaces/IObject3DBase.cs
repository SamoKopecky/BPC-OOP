namespace CV06.Entities.Interfaces
{
    interface IObject3DBase : IGraphicObjectBase
    {
        public double GetSurfaceArea();
        public double GetVolume();
    }
}