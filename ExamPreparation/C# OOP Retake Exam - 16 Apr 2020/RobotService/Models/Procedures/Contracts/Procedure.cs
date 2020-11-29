
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures.Contracts
{
    public abstract class Procedure : IProcedure
    {
        protected ICollection<IRobot> data;
        public Procedure()
        {
            this.data = new List<IRobot>();
        }
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (procedureTime > robot.ProcedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;

        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var robot in data)
            {
                sb.AppendLine(String.Format(OutputMessages.RobotInfo, robot.GetType().Name, robot.Name, robot.Happiness, robot.Energy));
            }
            return sb.ToString().Trim();
        }
    }
}
