
using WildFarm.Factories;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals.Contracts
{
    public interface IAnimal
    {       
        double WeightIncrease { get; }
        string MakeSound();
        void IsFoodAppropriate(Food.Food food);
    }
}
