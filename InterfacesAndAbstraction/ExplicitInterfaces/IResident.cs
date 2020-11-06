

namespace ExplicitInterfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; set; }
        string GetName();
    }
}
