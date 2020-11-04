

using System.Text;

namespace Cars
{
    public class Tesla : Car, IElectricCar
    {
        

        public Tesla(string model, string color, int battery)
            : base (model, color)
        {

            this.Battery = battery;
        }

        public int Battery { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
            sb.AppendLine(this.Start());
            sb.AppendLine(this.Stop());
            return sb.ToString().TrimEnd();
        }
    }
}
