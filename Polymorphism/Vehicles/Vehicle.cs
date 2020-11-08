using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;
        protected double tankCapacity;
        
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.IsAcTurnedOn = true;

        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }
        public double AcFuelIncrease { get; set; }
        public bool IsAcTurnedOn
        {
            get; set;
        }
        public virtual string Drive(double distance, double acFuelIncrease)
        {
            var fuelNeeded = 0.0;
            if (this.IsAcTurnedOn)
            {
                fuelNeeded = distance * (this.FuelConsumption + acFuelIncrease);
            }
            else
            {
                fuelNeeded = distance * this.FuelConsumption;
            }
            if (fuelNeeded <= this.FuelQuantity)
            {
                this.FuelQuantity -= fuelNeeded;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this.FuelQuantity + liters > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity += liters;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }

        }

    }
}
