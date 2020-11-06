using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite.Models
{
    public class Commando : SpecializedSoldier, ICommando
    {
        public Commando()
        {

        }
        private HashSet<Mission> missions;
        public Commando(string id, string firstname, string lastname, decimal salary, string corps)
            : base(id, firstname, lastname, salary, corps)
        {
           
        }
        public HashSet<Mission> Missions
        {
            get
            {
                return this.missions;
            }
        }

        HashSet<IMission> ICommando.missions { get; }

        public void ReadCommando(string[] cmdArgs, List<Soldier> allSoldiers)
        {
            var id = cmdArgs[1];
            var firstName = cmdArgs[2];
            var lastName = cmdArgs[3];
            var salary = decimal.Parse(cmdArgs[4]);
            var corps = cmdArgs[5];
            try
            {
                var commando = new Commando(id, firstName, lastName, salary, corps);
                var mission = new Mission();
                commando.missions = new HashSet<Mission>();
                commando.missions = mission.ReadMission(cmdArgs).ToHashSet();
                allSoldiers.Add(commando);              
            }
            catch (ArgumentException)
            {

            }          
        }
        public void CompleteMission(List<Mission> missions, Mission mission)
        {
            if (mission.State == "inProgress")
            {
                mission.State = "Finished";
            }
            missions.Remove(mission);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Firstname} {this.Lastname} Id: {this.Id} Salary: {this.Salary:F2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");
            if (this.Missions.Any())
            {
                sb.AppendLine($" {String.Join(Environment.NewLine, this.Missions)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
