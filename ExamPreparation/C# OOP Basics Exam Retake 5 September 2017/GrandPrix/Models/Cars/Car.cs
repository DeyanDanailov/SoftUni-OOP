
using GrandPrix.Models.Tyres;

namespace GrandPrix.Models.Cars
{
    public class Car : ICar
    {
        private const int FUEL_TANK_CAPACITY = 160;
        private double fuelAmount;
        public Car(int hp, double fuelAmount, ITyre tyre)
        {
            this.Hp = hp;
            this.FuelAmount = fuelAmount;
            this.Tyre = tyre;
        }
        public int Hp { get; private set; }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set
            {
                if (value > FUEL_TANK_CAPACITY)
                {
                    this.fuelAmount = FUEL_TANK_CAPACITY;
                }
                this.fuelAmount = value;
            }
        }

        public ITyre Tyre { get; set; }
    }
}
