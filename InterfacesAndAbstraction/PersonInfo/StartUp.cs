using System;
using System.Collections.Generic;
namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> citizensAndRobotsCollection =  new List <IIdentifiable>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split(" ");
                if (cmdArgs.Length == 2)
                {
                    IIdentifiable robot = new Robot(cmdArgs[0], cmdArgs[1]);
                    citizensAndRobotsCollection.Add(robot);
                }
                if (cmdArgs.Length == 3)
                {
                    IIdentifiable citizen = new Citizen(cmdArgs[0], int.Parse(cmdArgs[1]), cmdArgs[2]);
                    citizensAndRobotsCollection.Add(citizen);
                }
            }
            var fakeIdString = Console.ReadLine();
            var fakeLength = fakeIdString.Length;
            
            foreach (var item in citizensAndRobotsCollection)
            {
                var lastOfId = item.Id.Substring(item.Id.Length - fakeLength, fakeLength);
                if (lastOfId == fakeIdString)
                {                  
                    Console.WriteLine(item.Id);
                }
            }
           
        }
    }
}
