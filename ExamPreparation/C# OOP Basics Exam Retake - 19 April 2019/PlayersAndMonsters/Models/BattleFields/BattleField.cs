

using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Linq;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const string DEAD_PLAYER = "Player is dead!";
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(DEAD_PLAYER);
            }
            CheckIfBegginer(attackPlayer);
            CheckIfBegginer(enemyPlayer);

            attackPlayer.Health += attackPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();
            enemyPlayer.Health += enemyPlayer.CardRepository.Cards.Select(c => c.HealthPoints).Sum();

            while (true)
            {
                if (AttackerKillAttacked(attackPlayer, enemyPlayer))
                {
                    break;
                }
                if (AttackerKillAttacked(enemyPlayer, attackPlayer))
                {
                    break;
                }
            }

        }
        private IPlayer CheckIfBegginer(IPlayer player)
        {
            if (player.GetType().Name ==  nameof(Beginner))
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            return player;
        }
        private bool AttackerKillAttacked(IPlayer attacker, IPlayer attacked)
        {
            var attackerDamagePoints = attacker.CardRepository.Cards.Select(c => c.DamagePoints).Sum();
            attacked.TakeDamage(attackerDamagePoints);
            if (attacked.IsDead)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
