using System;
using System.Linq;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            try
            {
                var pizzaArgs = Console.ReadLine().Split();
                var pizzaName = pizzaArgs[1];

                var doughArgs = Console.ReadLine().Split();
                var flourType = doughArgs[1];
                var bakingTech = doughArgs[2];
                var doughWeight = double.Parse(doughArgs[3]);

                var dough = new Dough(flourType, bakingTech, doughWeight);
                var pizza = new Pizza(pizzaName,dough);
                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    var toppingArgs = command.Split();
                    var toppingType = toppingArgs[1];
                    var toppingWeight = double.Parse(toppingArgs[2]);
                    var topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.Calories:F2} Calories.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            

        }
    }
}
