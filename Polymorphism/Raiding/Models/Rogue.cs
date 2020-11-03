namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name, 80)
        {
            this.CastType = "hit";
        }

        protected override string CastType { get; }

        public override string CastAbility() => base.CastAbility() + " damage";
    }
}