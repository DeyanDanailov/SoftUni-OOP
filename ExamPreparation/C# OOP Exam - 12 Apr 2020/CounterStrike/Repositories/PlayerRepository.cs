using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private ICollection<IPlayer> models;
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.models.ToList().AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }
            this.models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
