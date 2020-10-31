using System;
using System.Collections.Generic;
using System.Linq;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                this.ValidateName(value);

                this.name = value;
            }
        }

        public int Rating
        {
            get
            {
                if (this.players.Count == 0)
                {
                    return 0;
                }

                return (int)Math.Round(this.players.Sum(p => p.OverallSkill) / this.players.Count);
            }

        }

        public void AddPlayer(Player player) => this.players.Add(player);

        public void RemovePlayer(string name)
        {
            var playerToRemove = this.players.FirstOrDefault(p => p.Name == name);

            if (playerToRemove == null)
            {
                var excMSG = string.Format(GlobalConstants.RemovingMissingPlayerExceptionMessage, name, this.name);
                throw new InvalidOperationException(excMSG);
            }

            this.players.Remove(playerToRemove);
        }

        public override string ToString() => $"{this.Name} - {this.Rating}";

        private void ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
            }
        }
    }
}
