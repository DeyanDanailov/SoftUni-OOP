
using GrandPrix.Models.Cars;
using GrandPrix.Models.Drivers;
using System.Collections.Generic;

namespace GrandPrix.Factories
{
    public class DriverFactory
    {
        public IDriver Produce(List<string> cmdArgs, ICar car, int lengthOfLap)
        {
            var type = cmdArgs[1];
            IDriver driver = null;
            var name = cmdArgs[2];
            if (type == "Aggressive")
            {                
                driver = new AggressiveDriver(name, car, lengthOfLap);
            }
            else if (type == "Endurance")
            {
                driver = new EnduranceDriver(name, car, lengthOfLap);
            }
            return driver;
        }
    }
}
