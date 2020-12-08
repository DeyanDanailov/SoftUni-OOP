

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private const string NULL_PLAYER = "Player cannot be null";
        private ICollection<IPlayer> players;
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException(NULL_PLAYER);
            }
            if (this.players.Any(p=> p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            return this.players.FirstOrDefault(p=>p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            if (player is null)
            {
                throw new ArgumentException(NULL_PLAYER);
            }
            if (this.players.Contains(player))
            {
                this.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
