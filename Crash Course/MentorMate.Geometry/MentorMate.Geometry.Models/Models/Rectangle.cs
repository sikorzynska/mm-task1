namespace MentorMate.Geometry.Models.Models
{
    public class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                width = value;
            }
        }

        public override double CalculatePerimeter()
        {
            var perimeter = 2 * (Length + Width);

            return perimeter;
        }

        public override double CalculateSurface()
        {
            var area = Length * Width;

            return area;
        }
    }
}
