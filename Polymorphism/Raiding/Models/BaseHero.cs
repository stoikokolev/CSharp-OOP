using Raiding.Models.Contracts;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected abstract string CastType { get; }

        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; }

        public int Power { get; }

        public virtual string CastAbility() => $"{this.GetType().Name} - {this.Name} {this.CastType} for {Power}";

    }
}
