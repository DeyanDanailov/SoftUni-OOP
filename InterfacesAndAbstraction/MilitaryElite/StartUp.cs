using System;
using System.Collections.Generic;
using MilitaryElite.Models;
namespace MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            var allSoldiers = new List<Soldier>();
            while ((command = Console.ReadLine()) != "End")
            {
                var cmdArgs = command.Split();
                var soldierType = cmdArgs[0];
                switch (soldierType)
                {
                    case "Private":
                        var privateS = new Private(cmdArgs[1], cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));
                        allSoldiers.Add(privateS);
                        break;
                    case "LieutenantGeneral":
                        var lieutenantGeneral = new LieutenantGeneral(cmdArgs[1], cmdArgs[2], cmdArgs[3], decimal.Parse(cmdArgs[4]));
                        lieutenantGeneral.GetPrivates(cmdArgs, allSoldiers);
                        allSoldiers.Add(lieutenantGeneral);
                        break;
                    case "Engineer":
                        var engineer = new Engineer();
                        engineer.ReadEngineer(cmdArgs, allSoldiers);
                        break;
                    case "Commando":
                        var commando = new Commando();
                        commando.ReadCommando(cmdArgs, allSoldiers);
                        break;
                    case "Spy":
                        var spy = new Spy(cmdArgs[1], cmdArgs[2], cmdArgs[3], int.Parse(cmdArgs[4]));
                        allSoldiers.Add(spy);
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine(String.Join(Environment.NewLine, allSoldiers));
        }

       
    }
}
