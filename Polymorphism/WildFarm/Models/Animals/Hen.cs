

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

        public override bool IsFoodAppropriate(BaseFood food)
        {
            var type = food.GetType().Name;
            if (type == "Vegetable" || type == "Fruit" || type == "Seeds" || type == "Meat")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
