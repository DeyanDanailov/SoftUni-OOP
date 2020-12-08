

using PlayersAndMonsters.Models.Cards.Contracts;
using System;

namespace PlayersAndMonsters.Models.Cards
{
    public abstract class Card : ICard
    {
        private const string INVALID_NAME = "Card's name cannot be null or an empty string.";
        private const string INVALID_DAMAGE_POINTS = "Card's damage points cannot be less than zero.";
        private const string INVALID_HEALTH_POINTS = "Card's HP cannot be less than zero.";
        private string name;
        private int damagePoints;
        private int healthPoints;
        public Card(string name, int damagePoints, int healthPoints)
        {
            this.Name = name;
            this.DamagePoints = damagePoints;
            this.HealthPoints = healthPoints;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(INVALID_NAME);
                }
                this.name = value;
            }
        }

        public int DamagePoints
        {
            get => this.damagePoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(INVALID_DAMAGE_POINTS);
                }
                this.damagePoints = value;
            }
        }

        public int HealthPoints
        {
            get => this.healthPoints;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(INVALID_HEALTH_POINTS);
                }
                this.healthPoints = value;
            }
        }
    }
}
