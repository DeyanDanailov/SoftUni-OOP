
using GrandPrix.Models.Cars;

namespace GrandPrix.Models.Drivers
{
    public class EnduranceDriver : Driver
    {
        private const double ENDURANCE_DRIVER_FUEL_CONS_PER_KM = 1.5;
        public EnduranceDriver(string name, ICar car, int lengthOfLap)
            : base(name, ENDURANCE_DRIVER_FUEL_CONS_PER_KM, car, lengthOfLap)
        {
        }
    }
}
