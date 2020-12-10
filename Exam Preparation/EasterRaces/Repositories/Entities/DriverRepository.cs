using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository : IRepository<IDriver>
    {
        private List<IDriver> models;

        public DriverRepository()
        {
            this.models = new List<IDriver>();
        }

        public IDriver GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public IReadOnlyCollection<IDriver> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(IDriver model)
        {
            this.models.Add(model);
        }

        public bool Remove(IDriver model)
        {
            return this.models.Remove(model);
        }
    }
}