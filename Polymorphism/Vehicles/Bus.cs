

namespace Vehicles
{
    public class Bus : Vehicle
    {
        
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.AcFuelIncrease = 1.4;
        }
       

    }
}
