

using System;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public double Radius {
            get
            {
                return this.radius;
            }
            private set
            {
                this.radius = value;
            }
        }

        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        public override double CalculatePerimeter()
        {
          
            return 2 * Math.PI * this.Radius;
        }
        public override string Draw()
        {
            //var sb = new StringBuilder();
            //double rIn = this.radius - 0.4;
            //double rOut = this.radius + 0.4;
            //for (double y = this.radius; y >= -this.radius; --y)
            //{
            //    for (double x = -this.radius; x < rOut; x += 0.5)
            //    {
            //        double value = x * x + y * y;
            //        if (value >= rIn * rIn && value < rOut * rOut)
            //        {
            //            sb.Append("*");
            //        }
            //        else
            //        {
            //            sb.Append(" ");
            //        }
            //    }
            //    sb.AppendLine();
            //}
            //return sb.ToString().TrimEnd();
            return base.Draw() + this.GetType().Name;
        }
        
    }
}
