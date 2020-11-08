

namespace Vehicles
{
    class Car : Vehicle
    {

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.AcFuelIncrease = 0.9;
        }



    }
}
