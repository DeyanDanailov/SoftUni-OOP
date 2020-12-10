

using GrandPrix.Models.Cars;

namespace GrandPrix.Models.Drivers
{
    public interface IDriver
    {
        string Name { get; }
        double TotalTime { get; set; }
        ICar Car { get; }
        double FuelConsumptionPerKm { get; }
        double Speed { get;  }
        string NotFinishingReason { get; set; }
    }
}
