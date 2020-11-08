using System;
using Raiding.Core;
using Raiding.Core.Contracts;

namespace Raiding
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
