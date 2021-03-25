namespace CV07.Entities
{
    class Rectangle : Object2DBase
    {
        public int Length { get; set; }
        public int Width { get; set; }

        public override double Area()
        {
            return Length * Width;
        }

        public override string ToString()
        {
            return $"Rectangle (length = {Length}, width = {Width})";
        }
    }
}