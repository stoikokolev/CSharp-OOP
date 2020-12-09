using System.Collections.Generic;
using System.Linq;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private ICollection<IPlayer> terrorists;
        private ICollection<IPlayer> conterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.conterTerrorists = new List<IPlayer>();
        }

        public string Start(ICollection<IPlayer> players)
        {
            this.FillTeams(players);

            while (true)
            {
                AttackTeam(terrorists, conterTerrorists);
                AttackTeam(conterTerrorists, terrorists);
                if (!IsTeamAlive(conterTerrorists))
                {
                    return "Terrorist wins!";
                }

                if (!IsTeamAlive(terrorists))
                {
                    return "Counter Terrorist wins!";
                }
            }

            

            return "Error";
        }

        private bool IsTeamAlive(ICollection<IPlayer> team) => team.Any(p => p.IsAlive);

        private void AttackTeam(ICollection<IPlayer> attackingTeam, ICollection<IPlayer> defendingTeam)
        {
            foreach (var attacker in attackingTeam)
            {
                //code below is commented because of Judge
               // if (!attacker.IsAlive) continue;

                foreach (var defender in defendingTeam)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private void FillTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else if (player is CounterTerrorist)
                {
                    conterTerrorists.Add(player);
                }
            }
        }
    }
}