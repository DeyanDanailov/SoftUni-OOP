﻿

using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;

namespace PlayersAndMonsters.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            IPlayer player = null;

            if (type == "Beginner")
            {
                player = new Beginner(username);
            }
            if (type == "Advanced")
            {
                player = new Advanced(username);
            }
            return player;
        }
    }
}
