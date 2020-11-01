using System;
using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = this.TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }

        private Corps TryParseCorps(string corpsStr)
        {
            if (Enum.TryParse<Corps>(corpsStr, out var corps))
            {
                throw new InvalidCorpsException();
            }
            return corps;
        }

        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}
