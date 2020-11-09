
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

        public override bool IsFoodAppropriate(BaseFood food)
        {
            var type = food.GetType().Name;
            if ( type == "Meat")
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
            return "Hoot Hoot";
        }
    }
}
