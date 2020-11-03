

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
            this.DefaultFuelConsumption = 1.25;
        }
        public double DefaultFuelConsumption { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public virtual void Drive(double kilometers)
        {
            if (this.Fuel >= kilometers* this.DefaultFuelConsumption)
            {
                this.Fuel -= kilometers * this.DefaultFuelConsumption;
            }
            else
            {
                System.Console.WriteLine("Not enough fuel!");
            }
        }
            
    }
}
