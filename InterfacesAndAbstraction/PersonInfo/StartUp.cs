using System;
using System.Collections.Generic;
using PersonInfo.Models;
using PersonInfo.Interfaces;
using System.Linq;

namespace PersonInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens =  new List <Citizen>();
            List<Rebel> rebels =  new List <Rebel>();
            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    citizens.Add(citizen);
                }
                if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    rebels.Add(rebel);
                }
            }
            var totalFood = 0;
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var person = citizens.Where(p => p.Name == command).FirstOrDefault();
                if (person != null)
                {
                    person.BuyFood();
                    totalFood += 10;
                }
                var reb = rebels.Where(p => p.Name == command).FirstOrDefault();
                if (reb != null)
                {
                    reb.BuyFood();
                    totalFood += 5;
                }
            }
            Console.WriteLine(totalFood);
           
        }
    }
}
