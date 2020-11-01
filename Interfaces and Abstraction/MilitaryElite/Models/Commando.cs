using System.Collections.Generic;
using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private ICollection<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)this.missions;

        public void AddMission(IMission mission)
        {
            this.missions.Add(mission);
        }
    }
}
