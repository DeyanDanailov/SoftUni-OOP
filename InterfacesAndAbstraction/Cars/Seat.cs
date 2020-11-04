

using System.Text;

namespace Cars
{
    public class Seat : Car, ICar
    {
       
        public Seat(string model, string color)
        : base (model, color) { }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
