using System;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split();
                var name = cmdArgs[0];
                var country = cmdArgs[1];
                var age = int.Parse(cmdArgs[2]);
                var human = new Citizen(name);
                human.Age = age;
                ((IResident)human).Country = country;
                Console.WriteLine(human.GetName());
                Console.WriteLine(((IResident)human).GetName());
            }
        }
    }
}
