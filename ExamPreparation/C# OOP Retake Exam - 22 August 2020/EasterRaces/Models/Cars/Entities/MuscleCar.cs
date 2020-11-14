

namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
            this.minHorsePower = 400;
            this.maxHorsePower = 600;
            this.CubicCentimeters = 5000;
        }
    }
}
