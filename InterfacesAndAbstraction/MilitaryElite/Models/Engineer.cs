using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Engineer : SpecializedSoldier, ISoldier, ISalary, ICorps
    {
        
        private List<Repair> repairs;
        public Engineer()
        {

        }

        public Engineer(string id, string firstname, string lastname, decimal salary, string corps)
            :base (id, firstname, lastname, salary, corps)
        {
          
        }
        public List<Repair> Repairs
        {
            get
            {
                return this.repairs;
            }
        }
        public void ReadEngineer(string[] cmdArgs, List<Soldier> allSoldiers)
        {
            var id = cmdArgs[1];
            var firstName = cmdArgs[2];
            var lastName = cmdArgs[3];
            var salary = decimal.Parse(cmdArgs[4]);
            var corps = cmdArgs[5];
            try
            {
                var engineer = new Engineer(id, firstName, lastName, salary, corps);
                var repair = new Repair();
                engineer.repairs = new List<Repair>();
                engineer.repairs = repair.ReadRepairs(cmdArgs).ToList();
                allSoldiers.Add(engineer);
            }
            catch (ArgumentException)
            {

            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Firstname} {this.Lastname} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Repairs:");
            if (this.Repairs.Any())
            {
                sb.AppendLine($" {String.Join(Environment.NewLine, this.Repairs)}");
            }
            
            return sb.ToString().TrimEnd();
        }
    }
}
