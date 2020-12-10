

namespace GrandPrix.Models.Tyres
{
    public interface ITyre
    {
        string Name { get;}
        double Hardness { get;}
        double Degradation { get; set; }
        void DegradateTyre();
        bool IsTyreBlown();
    }
}
