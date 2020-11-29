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
        private ICollection<IRobot> robots;
        private ICollection<IProcedure> procedures;
        private IGarage garage;
        public Controller()
        {
            this.robots = new List<IRobot>();
            this.procedures = new List<IProcedure>();
            this.garage = new Garage();
        }
        public string Charge(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure charge = new Charge();
            charge.DoService(currentRobot, procedureTime);
            this.procedures.Add(charge);
            return String.Format(OutputMessages.ChargeProcedure, currentRobot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure chip = new Chip();
            chip.DoService(currentRobot, procedureTime);
            this.procedures.Add(chip);

            return String.Format(OutputMessages.ChipProcedure, currentRobot.Name);
        }

        public string History(string procedureType)
        {
            var currentProcedure = this.procedures.FirstOrDefault(p => p.GetType().Name == procedureType);
            return currentProcedure.History();
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
            this.procedures.Add(polish);

            return String.Format(OutputMessages.PolishProcedure, currentRobot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure rest = new Rest();
            rest.DoService(currentRobot, procedureTime);
            this.procedures.Add(rest);

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
            this.procedures.Add(techCheck);
            return String.Format(OutputMessages.TechCheckProcedure, currentRobot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            var currentRobot = RobotExistsInGarage(robotName);
            IProcedure work = new Work();
            work.DoService(currentRobot, procedureTime);
            this.procedures.Add(work);

            return String.Format(OutputMessages.WorkProcedure, currentRobot.Name);
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
       
    }
}
