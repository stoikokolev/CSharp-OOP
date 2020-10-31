using System;
using FootballTeamGenerator.Common;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int STAT_MIN_VALUE = 0;
        private const int STAT_MAX_VALUE = 100;
        private const double STATS_COUNT = 5.0;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                this.ValidateStat(value, nameof(this.Endurance));

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                this.ValidateStat(value, nameof(this.Sprint));

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                this.ValidateStat(value, nameof(this.Dribble));

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                this.ValidateStat(value, nameof(this.Passing));

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                this.ValidateStat(value, nameof(this.Shooting));

                this.shooting = value;
            }
        }

        public double AverageStat =>
            Math.Round((this.sprint + this.endurance + this.shooting + this.dribble + this.passing) /
                             STATS_COUNT);

        private void ValidateStat(int value, string name)
        {
            if (value < STAT_MIN_VALUE || value > STAT_MAX_VALUE)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidStatExceptionMessage, name,
                    STAT_MIN_VALUE, STAT_MAX_VALUE));
            }
        }
    }
}
