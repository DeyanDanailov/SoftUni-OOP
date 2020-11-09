

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
            return true;
        }

        public override string MakeSound()
        {
            return "Cluck";
        }
    }
}
