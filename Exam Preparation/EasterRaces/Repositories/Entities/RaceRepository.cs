using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository:IRepository<IRace>
    {
        private List<IRace> models;

        public RaceRepository()
        {
            this.models = new List<IRace>();
        }

        public IRace GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IRace> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(IRace model)
        {
            this.models.Add(model);
        }

        public bool Remove(IRace model)
        {
            return this.models.Remove(model);
        }
    }
}