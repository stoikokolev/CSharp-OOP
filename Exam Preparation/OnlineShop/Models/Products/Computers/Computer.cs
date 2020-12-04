using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overall)
            : base(id, manufacturer, model, price, overall)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public void AddComponent(IComponent component)
        {
            if (this.components.Any(x => x.GetType().Name == component.GetType().Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || this.components.All(x => x.GetType().Name != componentType))
            {
                var msg = string.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name,
                    this.Id);
                throw new ArgumentException(msg);
            }

            IComponent toReturn = this.components.FirstOrDefault(x => x.GetType().Name == componentType);
            this.components.Remove(toReturn);
            return toReturn;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                var msg = string.Format(ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name,
                    this.GetType().Name, this.Id);
                throw new ArgumentException(msg);
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || this.peripherals.All(x => x.GetType().Name != peripheralType))
            {
                var msg = string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name,
                    this.Id);
                throw new ArgumentException(msg);
            }

            IPeripheral toReturn = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);
            this.peripherals.Remove(toReturn);
            return toReturn;
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + this.components.Average(x => x.OverallPerformance);
            }
        }

        public override decimal Price => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine($" Components ({this.components.Count}):");
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            sb.AppendLine(
                $" Peripherals ({this.peripherals.Count}); Average Overall Performance ({this.peripherals.Average(x => x.OverallPerformance):f2}):");

            foreach (var peripheral in this.peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return base.ToString() + sb.ToString().TrimEnd();
        }
    }
}