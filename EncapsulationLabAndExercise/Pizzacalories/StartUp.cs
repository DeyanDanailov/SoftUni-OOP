using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            while (command != "END")
            {
                var cmdArgs = command.Split();
                var flourType = cmdArgs[1];
                var bakingTech = cmdArgs[2];
                var weight = double.Parse(cmdArgs[3]);
                try
                {
                    var dough = new Models.Dough(flourType, bakingTech, weight);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message); 
                }
                command = Console.ReadLine();
            }
        }
    }
}
