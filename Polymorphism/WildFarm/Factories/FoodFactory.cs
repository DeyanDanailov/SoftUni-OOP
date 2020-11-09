
using System;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food ProduceFood(string[] foodArgs)
        {
            Food food = null;
            var type = foodArgs[0];
            int quantity = int.Parse(foodArgs[1]);
            switch (type)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;
                case "Fruit":
                    food = new Fruit(quantity);
                    break;
                case "Meat":
                    food = new Meat(quantity);
                    break;
                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:
                    throw new ArgumentException($"Invalid input!");
            }
            return food;
        }
    }
}
