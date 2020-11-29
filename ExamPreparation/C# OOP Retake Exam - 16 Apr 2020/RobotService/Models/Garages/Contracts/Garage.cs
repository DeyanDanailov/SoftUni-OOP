
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Garages.Contracts
{
    public class Garage : IGarage
    {
        private IDictionary<string, IRobot> robots;
        private const int Capacity = 10;
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count == 10)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (this.robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            this.robots[robot.Name] = robot;
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;

            this.robots.Remove(robotName);

        }
    }
}
