

using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly
               .GetExecutingAssembly()
               .GetTypes().FirstOrDefault(t => t.Name == type);
            ICard card = (ICard)Activator.CreateInstance(cardType, name);
            return card;
        }
    }
}
