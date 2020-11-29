

using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{

    public abstract class Computer : Product, IComputer
    {
        private ICollection<IComponent> components;
        private ICollection<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }
        public override double OverallPerformance => CalculateOverallPerformance();
        public override decimal Price => base.Price
            + this.Components.Sum(c => c.Price)
            + this.Peripherals.Sum(p => p.Price);
        public IReadOnlyCollection<IComponent> Components => this.components.ToList().AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.ToList().AsReadOnly();

        public void AddComponent(IComponent component)
        {
            if (this.components.Contains(component))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingComponent,
                    component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.peripherals.Contains(peripheral))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, this.GetType().Name, this.Id));
            }
            this.peripherals.Add(peripheral);
        }
        public IComponent RemoveComponent(string componentType)
        {
            if (this.components.Count == 0 || !this.components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingComponent,
                    componentType, this.GetType().Name, this.Id));
            }
            var componentToRemove = this.components.First(c => c.GetType().Name == componentType);
            this.components.Remove(componentToRemove);
            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.peripherals.Count == 0 || !this.peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, this.GetType().Name, this.Id));
            }
            var peripheralToRemove = this.peripherals.First(c => c.GetType().Name == peripheralType);
            this.peripherals.Remove(peripheralToRemove);
            return peripheralToRemove;
        }
        private double CalculateOverallPerformance()
        {

            if (this.Components.Count == 0)
            {
                return base.OverallPerformance;
            }
            else
            {
                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }
        public override string ToString()
        {
            double overrallP = this.peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0;
            var sb = new StringBuilder();
            sb
                .AppendLine(base.ToString())
                .AppendLine(String.Format(" " + SuccessMessages.ComputerComponentsToString, this.Components.Count))
                .AppendLine("  " + String.Join(Environment.NewLine + "  ", this.Components))
                .AppendLine(String.Format(" " + SuccessMessages.ComputerPeripheralsToString, this.Peripherals.Count, String.Format("{0:0.00}", overrallP)))
                .AppendLine("  " + String.Join(Environment.NewLine + "  ", this.Peripherals));

            return sb.ToString().Trim();
        }
    }
}
