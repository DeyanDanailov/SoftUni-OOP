using System;

namespace PlayersAndMonsters
{
    public static class StartUp
    {
        public static void Main(string[] args)
        {
            var master = new SoulMaster("Pesho", 39);
            Console.WriteLine(master);
        }
    }
}
