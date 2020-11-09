
using System;
using System.Collections.Generic;
using System.Linq;
using WildFarm.Factories;
using WildFarm.Models;
using WildFarm.Models.Food;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private ICollection<Animal> animals;
        public Engine()
        {
            this.AnimalFactory = new AnimalFactory();
            this.FoodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }
        public AnimalFactory AnimalFactory { get; }
        public FoodFactory FoodFactory { get; }
        public void Run()
        {
            string command;
            int cnt = 0;
            Animal animal = null;
            while ((command = Console.ReadLine()) != "End")
            {
               
                if (cnt % 2 == 0)
                {
                    var animalArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    animal = AnimalFactory.ProduceAnimal(animalArgs);
                }
                else
                {
                    var foodArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                    BaseFood food = FoodFactory.ProduceFood(foodArgs);
                    Console.WriteLine(animal.MakeSound());
                    if (animal.IsFoodAppropriate(food))
                    {
                        animal.EatFood(food.Quantity);
                    }
                    else
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                    }
                    animals.Add(animal);
                }
                cnt++;
            }
            Console.WriteLine(String.Join(Environment.NewLine, animals));
        }
        
    }
}
