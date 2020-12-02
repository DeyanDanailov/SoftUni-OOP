using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                foreach (var osama in terrorists)
                {
                    foreach (var bareta in counterTerrorists)
                    {                       
                        int damage = osama.Gun.Fire();
                        bareta.TakeDamage(damage);
                        if (bareta.IsAlive == false)
                        {
                            counterTerrorists.Remove(bareta);
                        }
                    }
                }
                if (!counterTerrorists.Any())
                {
                   return 
                }


            }

        }
    }
}
