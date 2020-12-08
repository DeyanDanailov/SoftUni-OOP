using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayersAndMonsters.Repositories
{
    class CardRepository : ICardRepository
    {
        private const string NULL_CARD = "Card cannot be null";
        private ICollection<ICard> cards;
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.ToList().AsReadOnly();

        public void Add(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException(NULL_CARD);
            }
            if (this.cards.Any(p => p.Name == card.Name))
            {
                throw new ArgumentException($"Player {card.Name} already exists!");
            }
            this.cards.Add(card);
        }

        public ICard Find(string name)
        {
            return this.cards.FirstOrDefault(p => p.Name == name);
        }

        public bool Remove(ICard card)
        {
            if (card is null)
            {
                throw new ArgumentException(NULL_CARD);
            }
            if (this.cards.Contains(card))
            {
                this.Remove(card);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
