using GrandPrix.Core;
using GrandPrix.Core.Contracts;
using System;

namespace GrandPrix
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
