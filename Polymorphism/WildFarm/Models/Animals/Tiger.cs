
using System;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            this.WeightIncrease = 1.0;
        }

        public override double WeightIncrease { get; }

        public override void IsFoodAppropriate(Food.Food food)
        {
            var type = food.GetType().Name;
            if (type == "Meat")
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
            return "ROAR!!!";
        }
    }
}
