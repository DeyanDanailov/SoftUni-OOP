

using WildFarm.Models;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
     public class AnimalFactory
    {
        public Animal ProduceAnimal(string[] animalArgs)
        { 
            Animal animal = null;
            var type = animalArgs[0];
            var name = animalArgs[1];

            switch (type)
            {
                case "Cat":
                case "Tiger":
                    var weight = double.Parse(animalArgs[2]);
                    string livingRegion = animalArgs[3];
                    string breed = animalArgs[4];
                    if (type == "Cat")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                    }
                    else if (type == "Tiger")
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                    }
                    break;
                case "Dog":
                case "Mouse":
                    weight = double.Parse(animalArgs[2]);
                    livingRegion = animalArgs[3];
                    if (type == "Dog")
                    {
                        animal = new Dog(name, weight, livingRegion);
                    }
                    else if (type == "Mouse")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                    }
                    break;
                case "Owl":
                case "Hen":
                    weight = double.Parse(animalArgs[2]);
                    var wingSize = double.Parse(animalArgs[3]);
                    if (type == "Owl")
                    {
                        animal = new Owl(name, weight, wingSize);
                    }
                    else if (type == "Mouse")
                    {
                        animal = new Hen(name, weight, wingSize);
                    }
                    break;
                default:
                    break;
            }
            return animal;
        }

    }
}
