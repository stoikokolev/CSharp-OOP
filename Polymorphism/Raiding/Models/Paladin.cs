namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name, 100)
        {
            this.CastType = "healed";
        }

        protected override string CastType { get; }
    }
}