using PizzaCalories.Common;
using System;

namespace PizzaCalories.Models
{
    public class Topping
    {
        private string type;
        private double weight;
        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                var newValue = value.ToLower();
                if (!(newValue == "meat" || newValue == "veggies" || newValue == "cheese" || newValue == "sauce"))
                {
                    throw new ArgumentException(String.Format(GlobalConstants.INVALID_TOPPING_TYPE, value));
                }
                this.type = value;
            }
        }
        
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < GlobalConstants.MIN_TOPPING_WEIGHT || value > GlobalConstants.MAX_TOPPING_WEIGHT)
                {
                    throw new ArgumentException(String.Format(GlobalConstants.INVALID_TOPPING_WEIGHT, "Meat"));
                }
                this.weight = value;
            }
        }
        public double Calories
        {
            get
            {
                return this.GetToppingCalories();
            }
        }
        private double GetToppingCalories()
        {
            double calories = 2 * this.Weight;
            var newType = this.Type.ToLower();
            switch (newType)
            {
                case "meat":
                    calories *= 1.2;
                    break;
                case "veggies":
                    calories *= 0.8;
                    break;
                case "cheese":
                    calories *= 1.1;
                    break;
                case "sauce":
                    calories *= 0.9;
                    break;
                default:
                    break;
            }            
            return calories;
        }
    }
}
