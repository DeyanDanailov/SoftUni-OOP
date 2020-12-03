using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
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
            var terrorists = this.players.Where(p => p.GetType().Name == nameof(Terrorist)).ToList();
            var counterTerrorists = this.players.Where(p => p.GetType().Name == nameof(CounterTerrorist)).ToList();
            while (true)
            {
                Shooting(terrorists, counterTerrorists);
                if (counterTerrorists.TrueForAll(c=>c.IsAlive == false))
                {
                    return "Terrorist wins!";
                }
                Shooting(counterTerrorists, terrorists);
                if (terrorists.TrueForAll(t=>t.IsAlive == false))
                {
                    return "Counter Terrorist wins!";
                }
            }
        }

        private static void Shooting(List<IPlayer> shooters, List<IPlayer> targets)
        {
            foreach (var shooter in shooters)
            {
                if (shooter.IsAlive)
                {
                    foreach (var target in targets)
                    {
                        int damage = shooter.Gun.Fire();
                        target.TakeDamage(damage);
                    }
                }
                
            }
        }
    }
}
