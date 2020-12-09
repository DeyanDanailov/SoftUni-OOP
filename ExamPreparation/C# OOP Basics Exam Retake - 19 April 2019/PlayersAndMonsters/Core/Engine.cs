

using PlayersAndMonsters.Core.Contracts;
using PlayersAndMonsters.IO;
using PlayersAndMonsters.IO.Contracts;
using System;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = new ManagerController();
        }
        public void Run()
        {
            while (true)
            {
                string[] inputArgs = reader.ReadLine().Split();
                string command = inputArgs[0];

                if (command == "Exit")
                {
                    Environment.Exit(0);
                }
                try
                {
                    string result = String.Empty;
                    switch (command)
                    {
                        case "AddPlayer":
                            var playertype = inputArgs[1];
                            var playerUsername = inputArgs[2];
                            result = managerController.AddPlayer(playertype, playerUsername);
                            break;
                        case "AddCard":
                            var cardType = inputArgs[1];
                            var cardName = inputArgs[2];
                            result = managerController.AddCard(cardType, cardName);
                            break;
                        case "AddPlayerCard":
                            var username = inputArgs[1];
                            var cardToAdd = inputArgs[2];
                            result = managerController.AddPlayerCard(username, cardToAdd);
                            break;
                        case "Fight":
                            var attacker = inputArgs[1];
                            var enemy = inputArgs[2];
                            result = managerController.Fight(attacker, enemy);
                            break;
                        case "Report":
                            result = managerController.Report();
                            break;
                        default:
                            break;
                    }
                    writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    continue;
                }
                
            }
           
        }
    }
}
