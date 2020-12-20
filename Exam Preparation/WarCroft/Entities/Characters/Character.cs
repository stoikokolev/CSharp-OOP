using System;
using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public abstract class Character
    {
        private string name;
        private double health;


        protected Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                this.name = value;
            }
        }

        public double BaseHealth { get; }

        public double Health
        {
            get => this.health;
            set
            {
                if (value <= 0)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else if (value > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double BaseArmor { get; }

        public double Armor { get; private set; }

        public double AbilityPoints { get; }
        
        public IBag Bag { get; }

        public bool IsAlive { get; private set; } = true;

        public void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();

            if (this.Armor < hitPoints)
            {
                hitPoints -= this.Armor;
                this.Armor = 0;

                if (hitPoints >= this.health)
                {
                    this.health = 0;
                    this.IsAlive = false;
                }
                else
                {
                    this.health -= hitPoints;
                }
            }
            else
            {
                this.Armor -= hitPoints;
            }
        }

        public void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
    }
}