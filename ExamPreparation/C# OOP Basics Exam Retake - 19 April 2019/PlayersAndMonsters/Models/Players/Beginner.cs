
namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player
    {
        private const int INITIAL_HEALTH = 50;
        public Beginner(string username)
            : base( username, INITIAL_HEALTH)
        {
        }
    }
}
