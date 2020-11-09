

using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            this.WeightIncrease = 0.3;
        }

        public override double WeightIncrease { get; }

        public override bool IsFoodAppropriate(BaseFood food)
        {
            var type = food.GetType().Name;
            if (type == "Vegetable" || type == "Meat")
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
            return "Meow";
        }
    }
}
