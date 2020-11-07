

using System;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {


                this.height = value;

            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {

                this.width = value;

            }
        }

        public override double CalculateArea()
        {
            return this.Height * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * (this.Height + this.Width);
        }
        public override string Draw()
        {
            //var sb = new StringBuilder();
            //sb.AppendLine(Drawline(this.width, '*', '*'));
            //for (int i = 1; i < this.height - 1; ++i)
            //{
            //    sb.AppendLine(Drawline(this.width, '*', ' '));
            //}
            //sb.AppendLine(Drawline(this.width, '*', '*'));
            //return sb.ToString().TrimEnd();
            return base.Draw() + this.GetType().Name;
        }

        //private string Drawline(double width, char end, char mid)
        //{
        //    var sb = new StringBuilder();
        //    sb.Append(end);
        //    for (int i = 1; i < width - 1; ++i)
        //    {
        //        sb.Append(mid);
        //    }
        //    sb.AppendLine((end).ToString());
        //    return sb.ToString().TrimEnd();
        //}
    }
}
