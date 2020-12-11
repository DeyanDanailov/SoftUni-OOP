

using GrandPrix.Core.Contracts;
using System;
using System.Linq;

namespace GrandPrix.Core
{
    public class Engine : IEngine
    {
        private IRaceTower raceTower;
        public Engine()
        {
            this.raceTower = new RaceTower();
        }
        public void Run()
        {
            var numberOfLaps = int.Parse(Console.ReadLine());
            var lengthOfLap = int.Parse(Console.ReadLine());
            this.raceTower.SetTrackInfo(numberOfLaps, lengthOfLap);
            while (true)
            {
                var cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = cmdArgs[0];
                try
                {
                    switch (command)
                    {
                        case "RegisterDriver":
                            this.raceTower.RegisterDriver(cmdArgs);
                            break;
                        case "CompleteLaps":
                            this.raceTower.CompleteLaps(cmdArgs);
                            break;
                        case "Leaderboard":
                            Console.WriteLine(this.raceTower.GetLeaderboard()); 
                            break;
                        case "ChangeWeather":
                            this.raceTower.ChangeWeather(cmdArgs);
                            break;
                        case "Box":
                            this.raceTower.DriverBoxes(cmdArgs);
                            break;
                        default:
                            break;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }

            }
        }
    }
}
