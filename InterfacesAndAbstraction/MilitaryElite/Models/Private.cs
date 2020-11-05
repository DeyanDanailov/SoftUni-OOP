using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Private : Soldier
    {
        public Private(string id, string firstname, string lastname, decimal salary)
            : base(id, firstname, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Firstname} {this.Lastname} Id: {this.Id} Salary: {this.Salary}");
            return sb.ToString().TrimEnd();
        }
    }
}
