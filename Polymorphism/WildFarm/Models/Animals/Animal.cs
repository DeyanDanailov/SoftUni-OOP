

using WildFarm.Models.Animals.Contracts;
using WildFarm.Models.Food;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract double WeightIncrease { get; }

        public abstract string MakeSound();
        public void EatFood(int quantity)
        {
            this.Weight += this.WeightIncrease * quantity;
            this.FoodEaten += quantity;
        }

        public abstract bool IsFoodAppropriate(BaseFood food);
    }
}
