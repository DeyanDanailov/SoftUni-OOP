using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private ICollection<IPlayer> players;
        public Map()
        {
            this.players = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = this.players.Where(p => p.GetType().Name == "Terrorist").ToList();
            var counterTerrorists = this.players.Where(p => p.GetType().Name == "CounterTerrorist").ToList();
            while (true)
            {
                Shooting(terrorists, counterTerrorists);
                if (!counterTerrorists.Any())
                {
                    return "Terrorist wins!";
                }
                Shooting(counterTerrorists, terrorists);
                if (!terrorists.Any())
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private static void Shooting(List<IPlayer> shooters, List<IPlayer> targets)
        {
            foreach (var shooter in shooters)
            {
                foreach (var target in targets)
                {
                    int damage = shooter.Gun.Fire();
                    target.TakeDamage(damage);
                    if (target.IsAlive == false)
                    {
                        targets.Remove(target);
                    }
                }
            }
        }
    }
}
