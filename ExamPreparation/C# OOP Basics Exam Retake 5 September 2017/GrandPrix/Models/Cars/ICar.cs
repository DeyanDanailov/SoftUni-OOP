
using GrandPrix.Models.Tyres;

namespace GrandPrix.Models.Cars
{
    public interface ICar
    {
        int Hp { get; }
        double FuelAmount { get; set; }
        ITyre Tyre { get; set; }
    }
}
