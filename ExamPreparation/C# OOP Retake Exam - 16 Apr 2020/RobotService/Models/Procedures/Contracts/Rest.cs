

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Contracts
{
    public class Rest : Procedure
    {
        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            robot.Energy += 10;
            robot.Happiness -= 3;
        }
    }
}
