

namespace EasterRaces.Models.Cars.Entities
{
    public class SportsCar : Car
    {
        public SportsCar(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {
            this.minHorsePower = 250;
            this.maxHorsePower = 450;
            this.CubicCentimeters = 3000;
        }
    }
}
