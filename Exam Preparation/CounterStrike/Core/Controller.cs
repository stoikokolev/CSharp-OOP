using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private IRepository<IGun> guns;
        private IRepository<IPlayer> players;
        private IMap map;

        public Controller()
        {
            this.guns=new GunRepository();
            this.players=new PlayerRepository();
            this.map=new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            if (type == nameof(Pistol))
            {
                gun=new Pistol(name,bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);
            var msg = string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
            return msg;
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);
            if (gun is null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player;
            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username,health,armor,gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health,armor,gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.players.Add(player);
            var msg = string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
            return msg;
        }

        public string StartGame()
        {
            return this.map.Start(players.Models.ToList());
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var player in players
                .Models
                .OrderBy(p=>p.GetType().Name)
                .ThenByDescending(p=>p.Health)
                .ThenBy(p=>p.Username))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}