using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Mission : IMission
    {
        private string state;
        public Mission()
        {

        }
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State {
            get
            {
                return this.state;
            } 
            set
            {
                if (value != "Finished" && value != "inProgress")
                {
                    throw new ArgumentException();
                }
                this.state = value;
            }
        }

       
        

        public HashSet <Mission> ReadMission(string [] cmdArgs)
        {
            var missions = new HashSet<Mission>();
            var mission = new Mission();
            for (int i = 6; i < cmdArgs.Length; i+=2)
            {
                try
                {
                    mission.CodeName = cmdArgs[i];
                    mission.State = cmdArgs[i + 1];
                    missions.Add(mission);
                }
                catch (ArgumentException)
                {                  
                }               
            }
            return missions;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.State == "inProgress")
            {
                sb.AppendLine($"Code Name: {this.CodeName} State: {this.State}");
            }          
            return sb.ToString().TrimEnd();
        }
    }
}
