using System;

namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        private string username;
        private int level;
        private const int HERO_MIN_LEVEL = 0;

        public Hero(string username, int level)
        {
            this.Username = username;
            this.Level = level;
        }

        public string Username
        {
            get => this.username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Username cannot be null or whitespace!");
                }
                else
                {
                    this.username = value;
                }
            }
        }

        public int Level
        {
            get => this.level;
            private set
            {
                if (value < HERO_MIN_LEVEL)
                {
                    throw new ArgumentException("Level cannot be negative number!");
                }
                else
                {
                    this.level = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
