

using GrandPrix.Models.Cars;

namespace GrandPrix.Models.Drivers
{
    public abstract class Driver : IDriver
    {
        private int lengthOfLap;
        public Driver(string name, double fuelConsPerKm, ICar car, int lengthOfLap)
        {
            this.Name = name;
            this.FuelConsumptionPerKm = fuelConsPerKm;
            this.Car = car;
            this.lengthOfLap = lengthOfLap;
            this.CalculateSpeed();
        }
        public string Name { get; private set; }

        public double TotalTime { get; set; }
     
        public ICar Car { get; private set; }
        public double FuelConsumptionPerKm { get; private set; }
        public virtual double Speed => this.CalculateSpeed();    
        
        public string NotFinishingReason { get; set; } = string.Empty;
        private double CalculateSpeed()
        {
           return (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        }
    }
}
