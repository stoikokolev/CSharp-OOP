using System.Collections.Generic;
using Raiding.Core.Contracts;
using Raiding.Exceptions;
using Raiding.Factories;
using Raiding.IO.Contracts;
using Raiding.Models.Contracts;

namespace Raiding.Core
{
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private ICollection<IHero> heroes;
        private HeroFactory heroFactory;

        private Engine()
        {
            this.heroes = new List<IHero>();
            this.heroFactory = new HeroFactory();
        }

        public Engine(IReader reader, IWriter writer)
        : this()
        {
            this.writer = writer;
            this.reader = reader;
        }

        public void Run()
        {
            CreateRidingGroup();

            var bossHealth = int.Parse(reader.Read());
            var groupPower = 0;

            foreach (var hero in this.heroes)
            {
                writer.WriteLine(hero.CastAbility());
                groupPower += hero.Power;
            }

            writer.WriteLine(groupPower >= bossHealth ? "Victory!" : "Defeat...");
        }

        private void CreateRidingGroup()
        {
            var repeats = int.Parse(reader.Read());
            while (this.heroes.Count != repeats)
            {
                var name = reader.Read();
                var type = reader.Read();
                try
                {
                    var hero = heroFactory.CreateHero(name, type);
                    this.heroes.Add(hero);
                }
                catch (InvalidHeroException ihe)
                {
                    writer.WriteLine(ihe.Message);
                }
            }
        }
    }
}
