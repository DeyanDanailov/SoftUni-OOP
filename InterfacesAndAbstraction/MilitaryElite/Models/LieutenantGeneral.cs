using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Soldier, ISalary
    {
        private HashSet<Soldier> privates;

        public LieutenantGeneral(string id, string firstname, string lastname, decimal salary)
            :base (id, firstname, lastname)
        {
            this.Salary = salary;
            this.privates = new HashSet<Soldier>();
        }

        public decimal Salary { get; private set; }
        public HashSet<Soldier> Privates
        {
            get
            {
                return this.privates;
            }
        }
        public void GetPrivates(string[] cmdArgs, List<Soldier> allSoldiers)
        {
            
            for (int i = 5; i < cmdArgs.Length; i++)
            {
                var privateId = cmdArgs[i];
                this.privates.Add(allSoldiers.Where(s => s.Id == privateId).FirstOrDefault());               
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Firstname} {this.Lastname} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine("Privates:");
            if (this.Privates.Any())
            {
                sb.AppendLine($" {String.Join(Environment.NewLine, this.Privates)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
