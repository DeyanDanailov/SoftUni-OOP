using System;
using System.Collections.Generic;
using PizzaCalories.Common;

namespace PizzaCalories.Models
{
    public class Pizza
    {
        private string name;
       
        private readonly List<Topping> toppings;
        public Pizza()
        {
            this.toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough)
            : this()
        {
            this.Name = name;
            this.Dough = dough;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value) || value.Length < GlobalConstants.MIN_PIZZA_NAME 
                    || value.Length > GlobalConstants.MAX_PIZZA_NAME)
                {
                    throw new ArgumentException(GlobalConstants.INVALID_PIZZA_NAME);
                }
                this.name = value;
            }
        }
        public int CountOfToppings => this.toppings.Count;
        public double Calories => this.GetPizzaCalories();
        public Dough Dough { get; }
        
        public void AddTopping(Topping topping)
        {
            if (CountOfToppings<10)
            {
                this.toppings.Add(topping);
            }
            else
            {
                throw new ArgumentException(GlobalConstants.INVALID_TOPPING_NUMBER);
            }
        }
        public double GetPizzaCalories()
        {
            double pizzaCalories = Dough.Calories;
            foreach (var topping in this.toppings)
            {
                pizzaCalories += topping.Calories;
            }
            return pizzaCalories;
        }
    }
}
