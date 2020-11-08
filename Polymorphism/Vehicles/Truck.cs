

using System;

namespace Vehicles
{
    class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.AcFuelIncrease = 1.6;
        }

        public override void Refuel(double liters)
        {
            if (liters > 0)
            {
                if (this.FuelQuantity + liters > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {

                    this.FuelQuantity += liters * 0.95;
                }
            }
            else
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            
        }
    }
}
