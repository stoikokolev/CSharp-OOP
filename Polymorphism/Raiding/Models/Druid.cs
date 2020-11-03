namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name, 80)
        {
            this.CastType = "healed";
        }

        protected override string CastType { get; }
    }
}
