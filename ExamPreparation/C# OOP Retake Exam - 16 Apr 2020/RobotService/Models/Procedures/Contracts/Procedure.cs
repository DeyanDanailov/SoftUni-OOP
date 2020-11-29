
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
        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (procedureTime > robot.ProcedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
            data.Add(robot);
        }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            foreach (var robot in data)
            {
                sb.AppendLine($" Robot type: {robot.GetType().Name} - {robot.Name} - Happiness: {robot.Happiness} - Energy: {robot.Energy}");
            }
            return sb.ToString().Trim();
        }
    }
}
