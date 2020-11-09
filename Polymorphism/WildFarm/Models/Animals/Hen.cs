

using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
            this.WeightIncrease = 0.35;
        }

        public override double WeightIncrease { get; }

        public override void IsFoodAppropriate(Food.Food food)
        {
            this.EatFood(food.Quantity);
        }

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
