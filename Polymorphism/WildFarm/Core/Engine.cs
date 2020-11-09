
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
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
            this.animals = new List<Animal>();
        }
        private AnimalFactory animalFactory { get; }
        private FoodFactory foodFactory { get; }
        public void Run()
        {
            string command;
           // int cnt = 0;
            Animal animal = null;
            while ((command = Console.ReadLine()) != "End")
            {
                if (cnt % 2 == 0)
                {
                    var animalArgs = command.Split();
                    animal = animalFactory.ProduceAnimal(animalArgs);
                }
                else
                {
                    var foodArgs = command.Split();
                    BaseFood food = foodFactory.ProduceFood(foodArgs);
                    Console.WriteLine(animal.MakeSound());
                    if (animal.IsFoodAppropriate(food))
                    {
                        animal.EatFood(food.Quantity);
                    }
                    else
                    {
                        Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                    }

                    if (animal != null)
                    {
                        animals.Add(animal);
                    }
                }
                cnt++;
            }
            Console.WriteLine(String.Join(Environment.NewLine, animals));
        }

    }
}
