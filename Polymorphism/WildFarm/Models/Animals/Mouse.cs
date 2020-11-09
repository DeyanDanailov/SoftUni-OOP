

using System;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            this.WeightIncrease = 0.1;
        }

        public override double WeightIncrease { get; }

        public override void IsFoodAppropriate(Food.Food food)
        {
            var type = food.GetType().Name;
            if (type == "Vegetable" || type == "Fruit")
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
            return "Squeak";
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]");
            return sb.ToString().TrimEnd();
        }
    }
}
