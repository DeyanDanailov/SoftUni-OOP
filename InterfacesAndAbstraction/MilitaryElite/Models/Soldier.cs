
using MilitaryElite.Interfaces;
namespace MilitaryElite.Models
{
     public abstract class Soldier
    {
        public Soldier()
        {

        }
        public Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.Firstname = firstName;
            this.Lastname = lastName;
        }

        public string Id { get; private set; }

        public string Firstname { get; private set; }

        public string Lastname { get; private set; }
        
    }
}
