

using GrandPrix.Core.Contracts;
using System;
using System.Linq;

namespace GrandPrix.Core
{
    public class Engine : IEngine
    {
        private IRaceTower raceTower;
        public Engine(int numberOfLaps, int lengthOfLap)
        {
            this.raceTower = new RaceTower(numberOfLaps, lengthOfLap);
        }
        public void Run()
        {            
            
            while (true)
            {
                var cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = cmdArgs[0];
                try
                {
                    switch (command)
                    {
                        case "RegisterDriver":
                            raceTower.RegisterDriver(cmdArgs);
                            break;
                        case "CompleteLaps":
                            raceTower.CompleteLaps(cmdArgs);
                            break;
                        case "Leaderboard":
                            Console.WriteLine(raceTower.GetLeaderboard()); 
                            break;
                        case "ChangeWeather":
                            raceTower.ChangeWeather(cmdArgs);
                            break;
                        case "Box":
                            raceTower.DriverBoxes(cmdArgs);
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
