

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Contracts
{
    public class TechCheck : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            if (robot.IsChecked == true)
            {
                robot.Energy -= 16;
            }
            else
            {
                robot.Energy -= 8;
                robot.IsChecked = true;
            }
        }
    }
}
