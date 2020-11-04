using System;
using System.Linq;
using PizzaCalories.Core;
using PizzaCalories.Models;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Run();

        }
    }
}
