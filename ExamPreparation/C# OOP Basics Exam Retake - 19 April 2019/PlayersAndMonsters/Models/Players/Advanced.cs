
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player
    {
        private const int INITIAL_HEALTH = 250;
        public Advanced( string username)
            : base( username, INITIAL_HEALTH)
        {
        }
    }
}
