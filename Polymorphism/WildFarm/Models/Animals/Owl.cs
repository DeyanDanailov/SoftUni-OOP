
using System;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            this.WeightIncrease = 0.25;
        }

        public override double WeightIncrease { get; }

        public override void IsFoodAppropriate(Food.Food food)
        {
            var type = food.GetType().Name;
            if ( type == "Meat")
            {
                this.EatFood(food.Quantity);
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
    }
}
