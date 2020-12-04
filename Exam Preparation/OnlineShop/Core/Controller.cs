using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers=new List<IComputer>();
            this.components=new List<IComponent>();
            this.peripherals=new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            Computer computer;

            if (computerType == ComputerType.DesktopComputer.ToString())
            {
                computer=new DesktopComputer(id,manufacturer,model,price);
            }
            else if (computerType == ComputerType.Laptop.ToString())
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (this.computers.Any(x => x.Id == computer.Id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);

        }
        
        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            this.CheckIfComputerExistById(computerId);

            Peripheral peripheral;

            if (peripheralType == PeripheralType.Headset.ToString())
            {
                peripheral = new Headset(id,manufacturer,model,price,overallPerformance,connectionType);
            }
            else if (peripheralType == PeripheralType.Monitor.ToString())
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Mouse.ToString())
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == PeripheralType.Keyboard.ToString())
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            if (this.peripherals.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            this.peripherals.Add(peripheral);
            var computer = this.GetComputerById(computerId);
            computer.AddPeripheral(peripheral);

            var msg = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
            return msg;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.CheckIfComputerExistById(computerId);
            var computer = this.GetComputerById(computerId);
            
            var peripheral = computer.RemovePeripheral(peripheralType);
            this.peripherals.Remove(peripheral);

            var msg = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
            return msg;
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            this.CheckIfComputerExistById(computerId);

            Component component;

            if (componentType == ComponentType.CentralProcessingUnit.ToString())
            {
                component=new CentralProcessingUnit(id,manufacturer,model,price,overallPerformance,generation);
            }
            else if (componentType == ComponentType.Motherboard.ToString())
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.PowerSupply.ToString())
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.SolidStateDrive.ToString())
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.RandomAccessMemory.ToString())
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == ComponentType.VideoCard.ToString())
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            if (this.components.Any(x => x.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            this.components.Add(component);
            var computer = this.GetComputerById(computerId);
            computer.AddComponent(component);

            var msg = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
            return msg;
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.CheckIfComputerExistById(computerId);
            var computer = this.GetComputerById(computerId);

            var component = computer.RemoveComponent(componentType);
            this.components.Remove(component);

            var msg =string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
            return msg;
        }

        public string BuyComputer(int id)
        {
            this.CheckIfComputerExistById(id);
            var computer = this.GetComputerById(id);
            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var computer = this.computers
                .Where(x => x.Price <= budget)
                .OrderByDescending(x => x.OverallPerformance)
                .FirstOrDefault();

            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer,budget));
            }

            this.computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            this.CheckIfComputerExistById(id);

            var computer = this.GetComputerById(id);

            return computer.ToString();
        }

        private void CheckIfComputerExistById(int id)
        {
            if (this.computers.All(x => x.Id != id))
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
        }

        private IComputer GetComputerById(int id)
        {
            return this.computers.FirstOrDefault(x => x.Id == id);
        }
    }
}