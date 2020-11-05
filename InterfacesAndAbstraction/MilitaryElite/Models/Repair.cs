using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Repair : IRepair
    {
        public Repair()
        {

        }
        public Repair(string part, int hours)
        {
            this.Part = part;
            this.Hours = hours;
        }

        public string Part { get; private set; }

        public int Hours { get; private set; }
        public List<Repair> ReadRepairs(string[] cmdArgs)
        {
            var repairs = new List<Repair>();
            
            for (int i = 6; i < cmdArgs.Length; i += 2)
            {
                var repair = new Repair();
                repair.Part = cmdArgs[i];
                repair.Hours = int.Parse(cmdArgs[i + 1]);
                repairs.Add(repair);

            }
            return repairs;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Part Name: {this.Part} Hours Worked: {this.Hours}");
            return sb.ToString().TrimEnd();
        }
    }
}
