using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;
        public Controller()
        {
            this.map = new Map();
            this.players = new PlayerRepository();
            this.guns = new GunRepository();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun = CreateGun(type, name, bulletsCount);

            this.guns.Add(gun);

            string msg = string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);

            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = this.guns.FindByName(gunName);
            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }
            IPlayer player = CreatePlayer(type, username, health, armor, gun);
            this.players.Add(player);
            string msg = string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);

            return msg;
        }

        public string Report()
        {
            var orderedPlayers = this.players.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username);

            var sb = new StringBuilder();

            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }

        public string StartGame()
        {
            
            return this.map.Start(this.players.Models.ToList());
        }
        private IPlayer CreatePlayer(string type, string username, int health, int armor, IGun gun)
        {
            IPlayer player = null;
            if (type == nameof(Terrorist))
                player = new Terrorist(username, health, armor, gun);
            else if (type == nameof(CounterTerrorist))
                player = new CounterTerrorist(username, health, armor, gun);
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            return player;
        }
        private IGun CreateGun(string type, string name, int bulletsCount)
        {
            IGun gun = null;
            if (type == nameof(Pistol))
                gun = new Pistol(name, bulletsCount);
            else if (type == nameof(Rifle))
                gun = new Rifle(name, bulletsCount);
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            return gun;
        }
    }
}
