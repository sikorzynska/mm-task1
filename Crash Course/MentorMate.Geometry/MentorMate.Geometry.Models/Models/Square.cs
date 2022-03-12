namespace MentorMate.Geometry.Models.Models
{
    public class Square : Shape
    {
        private double side;

        public Square(double side)
        {
            this.Side = side;
        }

        public double Side
        {
            get
            {
                return side;
            }
            private set
            {
                side = value;
            }
        }

        public override double CalculatePerimeter()
        {
            var perimeter = side * side;

            return perimeter;
        }

        public override double CalculateSurface()
        {
            var area = 4 * side;

            return area;
        }
    }
}
