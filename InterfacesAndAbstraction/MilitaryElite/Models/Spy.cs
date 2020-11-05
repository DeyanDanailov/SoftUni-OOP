using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Spy : Soldier
    {
       

        public Spy( string id, string firstname, string lastname, int codeNumber)
            :base (id, firstname, lastname)
        {
            this.CodeNumber = codeNumber;
        }

 
        public int CodeNumber { get; private set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Firstname} {this.Lastname} Id: {this.Id}");
            sb.AppendLine($"Code Number: {this.CodeNumber}");
            return sb.ToString().TrimEnd();
        }
    }
}
