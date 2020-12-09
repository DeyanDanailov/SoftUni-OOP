

using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories;
using PlayersAndMonsters.Repositories.Contracts;
using System;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private const string INVALID_USERNAME = "Player's username cannot be null or an empty string.";
        private const string INVALID_HEALTH = "Player's health bonus cannot be less than zero.";
        private const string INVALID_DAMAGE = "Damage points cannot be less than zero.";
        private string username;
        private int health;
        private readonly ICardRepository cardRepository;
        public Player(string username, int health)
        {
            this.cardRepository = new CardRepository();
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository => this.cardRepository;

        public string Username {
            get => this.username;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(INVALID_USERNAME);
                }
                this.username = value;
            }
        }

        public int Health
        {
            get => this.health;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(INVALID_HEALTH);
                }
                this.health = value;
            }
        }

        public bool IsDead { get; private set; } = false;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException(INVALID_DAMAGE);
            }
            if (damagePoints >= this.Health)
            {
                this.IsDead = true;
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
                       
        }
    }
}
