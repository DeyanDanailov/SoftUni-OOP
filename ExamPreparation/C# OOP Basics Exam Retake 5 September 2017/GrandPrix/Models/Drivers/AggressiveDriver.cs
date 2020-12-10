

using GrandPrix.Models.Cars;

namespace GrandPrix.Models.Drivers
{
    public class AggressiveDriver : Driver
    {
        private const double AGGRESIVE_DRIVER_FUEL_CONS_PER_KM = 2.7;
        private const double AGGRESIVE_DRIVER_SPEED_MULTIPLYER = 1.3;

        public AggressiveDriver(string name, ICar car, int lengthOfLap)
            : base(name, AGGRESIVE_DRIVER_FUEL_CONS_PER_KM, car, lengthOfLap)
        {
        }

        public override double Speed => base.Speed*AGGRESIVE_DRIVER_SPEED_MULTIPLYER;
    }
}
