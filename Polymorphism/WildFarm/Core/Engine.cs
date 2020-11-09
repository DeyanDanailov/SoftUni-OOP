
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

           
            while ((command = Console.ReadLine()) != "End")
            {
                
                var animalArgs = command.Split();
                Animal animal = animalFactory.ProduceAnimal(animalArgs);
                
                    this.animals.Add(animal);
                

                var foodArgs = Console.ReadLine().Split();
                Food food = foodFactory.ProduceFood(foodArgs);
                Console.WriteLine(animal.MakeSound());
                try
                {
                    animal.IsFoodAppropriate(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    continue;
                }
            }
            foreach (var item in this.animals)
            {
                Console.WriteLine(item.ToString());
            }
            
        }

    }
}
