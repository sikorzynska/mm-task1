namespace MentorMate.Geometry.Models.Models
{
    public class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;
        private double semiPerimeter;

        public Triangle(double a, double b, double c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            semiPerimeter = (a + b + c) / 2;
        }

        public double A 
        {
            get
            {
                return a;
            } 
            private set
            {
                a = value;
            } 
        }

        public double B
        {
            get
            {
                return b;
            }
            private set
            {
                b = value;
            }
        }

        public double C
        {
            get
            {
                return c;
            }
            private set
            {
                c = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = a + b + c;

            return perimeter;
        }

        public override double CalculateSurface()
        {
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }
    }
}
