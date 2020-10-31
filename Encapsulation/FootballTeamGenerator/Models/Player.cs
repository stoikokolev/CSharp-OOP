using System;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;


        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.EmptyNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public Stats Stats { get; }

        public double OverallSkill => this.Stats.AverageStat;
    }
}
