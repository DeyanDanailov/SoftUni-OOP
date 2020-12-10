using GrandPrix.Core;
using GrandPrix.Core.Contracts;
using System;

namespace GrandPrix
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfLaps = int.Parse(Console.ReadLine());
            var lengthOfLap = int.Parse(Console.ReadLine());
            IEngine engine = new Engine(numberOfLaps, lengthOfLap);
            engine.Run();
        }
    }
}
