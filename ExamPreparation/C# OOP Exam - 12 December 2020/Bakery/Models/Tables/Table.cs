

using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IBakedFood> foodOrders;
        private readonly ICollection<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal price;
        private decimal pricePerPerson;
        public Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
            :this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public int TableNumber { get; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return this.pricePerPerson; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved { get; private set; } = false;

        public decimal Price
        {
            get { return this.price; }
            private set
            {
                this.price = this.NumberOfPeople*this.PricePerPerson;
            }
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            return this.foodOrders.Select(f => f.Price).Sum()
                + this.drinkOrders.Select(f => f.Price).Sum() 
                + this.numberOfPeople*this.pricePerPerson;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.
                AppendLine($"Table: {this.TableNumber}").
                AppendLine($"Type: {this.GetType().Name}").
                AppendLine($"Capacity: {this.Capacity}").
                AppendLine($"Price per Person: {this.PricePerPerson}");

            return sb.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
