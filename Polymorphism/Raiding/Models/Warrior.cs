namespace Raiding.Models
{
    class Warrior : BaseHero
    {
        public Warrior(string name)
            : base(name, 100)
        {
            this.CastType = "hit";
        }

        protected override string CastType { get; }

        public override string CastAbility() => base.CastAbility() + " damage";
    }
}