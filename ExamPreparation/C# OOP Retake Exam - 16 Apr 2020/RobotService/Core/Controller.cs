using RobotService.Core.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IDictionary<string, List<IRobot>> procedures;
        private IGarage garage;
        public Controller()
        {
            this.procedures = new Dictionary<string, List<IRobot>>();
            this.garage = new Garage();
        }

        public string Charge(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure charge = new Charge();
            charge.DoService(currentRobot, procedureTime);
            AddProcedure(charge, currentRobot);

            return String.Format(OutputMessages.ChargeProcedure, currentRobot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure chip = new Chip();
            chip.DoService(currentRobot, procedureTime);
            AddProcedure(chip, currentRobot);

            return String.Format(OutputMessages.ChipProcedure, currentRobot.Name);
        }

        public string History(string procedureType)
        {
            var robots = this.procedures[procedureType];

            var sb = new StringBuilder();
            sb.AppendLine(procedureType);
            foreach (var robot in robots)
            {
                sb.AppendLine(String.Format(OutputMessages.RobotInfo, robot.GetType().Name, robot.Name, robot.Happiness, robot.Energy));
            }
            return sb.ToString().Trim();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = ProduceRobot(robotType, name, energy, happiness, procedureTime);
            this.garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure polish = new Polish();
            polish.DoService(currentRobot, procedureTime);
            AddProcedure(polish, currentRobot);


            return String.Format(OutputMessages.PolishProcedure, currentRobot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure rest = new Rest();
            rest.DoService(currentRobot, procedureTime);
            AddProcedure(rest, currentRobot);


            return String.Format(OutputMessages.RestProcedure, currentRobot.Name);
        }

        public string Sell(string robotName, string ownerName)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            this.garage.Sell(currentRobot.Name, ownerName);
            if (currentRobot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure techCheck = new TechCheck();
            techCheck.DoService(currentRobot, procedureTime);
            AddProcedure(techCheck, currentRobot);

            return String.Format(OutputMessages.TechCheckProcedure, currentRobot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure work = new Work();
            work.DoService(currentRobot, procedureTime);
            AddProcedure(work, currentRobot);


            return String.Format(OutputMessages.WorkProcedure, currentRobot.Name, procedureTime);
        }
        private IRobot RobotExistsInGarage(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            return this.garage.Robots[robotName];
        }
        private IRobot ProduceRobot(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;
            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;

                default:
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));

            }
            return robot;
        }
        private void AddProcedure(IProcedure current, IRobot robot)
        {
            if (this.procedures.ContainsKey(current.GetType().Name))
            {
                this.procedures[current.GetType().Name].Add(robot);
            }
            else
            {
                this.procedures[current.GetType().Name] = new List<IRobot>();
                this.procedures[current.GetType().Name].Add(robot);
            }
        }

    }
}
