using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public ICar GetByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Model == name);
        }

        public IReadOnlyCollection<ICar> GetAll()
        {
            return this.models.AsReadOnly();
        }

        public void Add(ICar model)
        {
            this.models.Add(model);
        }

        public bool Remove(ICar model)
        {
            return this.models.Remove(model);
        }
    }
}