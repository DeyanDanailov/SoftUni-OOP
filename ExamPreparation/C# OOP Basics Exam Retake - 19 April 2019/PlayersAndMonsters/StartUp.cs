namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;


    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}