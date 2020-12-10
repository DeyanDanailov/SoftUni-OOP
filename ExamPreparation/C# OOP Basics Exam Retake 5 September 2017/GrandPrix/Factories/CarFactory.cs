
using GrandPrix.Models.Cars;
using GrandPrix.Models.Tyres;
using System.Collections.Generic;

namespace GrandPrix.Factories
{
    public class CarFactory
    {
        public ICar Produce(List<string> cmdArgs, ITyre tyre)
        {
            var hp = int.Parse(cmdArgs[3]);
            var fuelAmount = double.Parse(cmdArgs[4]);
            ICar car = new Car(hp, fuelAmount, tyre);

            return car;
        }
    }
}
