

using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;

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
            

        }
        private IPlayer CheckIfBegginer(IPlayer player)
        {
            if (player is Beginner)
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            return player;
        }
    }
}
