using Raiding.Exceptions;
using Raiding.Models;
using Raiding.Models.Contracts;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public IHero CreateHero(string name, string type)
        {
            IHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }

            if (hero == null)
            {
                throw new InvalidHeroException();
            }

            return hero;
        }
    }
}
