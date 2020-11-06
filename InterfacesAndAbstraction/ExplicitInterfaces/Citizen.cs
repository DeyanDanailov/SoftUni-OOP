

namespace ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        

        public Citizen(string name)
        {
            this.Name = name;
            
        }

        public string Name { get; private set; }

        public int Age { get; set; }

        string IResident.Name { get; }

        string IResident.Country { get; set; }
        

        public string GetName()
        {
            return this.Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
