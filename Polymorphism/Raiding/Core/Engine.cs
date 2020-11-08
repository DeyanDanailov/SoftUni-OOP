
using System;
using System.Collections.Generic;
using Raiding.Core.Contracts;
using Raiding.Factories;
using Raiding.Models;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private HeroFactory heroFactory;
        private ICollection<BaseHero> heroes;
        public Engine()
        {
            this.heroFactory = new HeroFactory();
            this.heroes = new List<BaseHero>();
        }
        public void Run()
        {
            var n = int.Parse(Console.ReadLine());
            string name = String.Empty;
            int cnt = 0;
            while (heroes.Count < n)
            {                
                if (cnt%2==0)
                {
                    name = Console.ReadLine();
                }
                else
                {
                    try
                    {
                        var type = Console.ReadLine();
                        heroes.Add(heroFactory.ProduceHero(type, name));                        
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message); 
                    }                   
                }
                cnt++;
            }
            var bossPower = int.Parse(Console.ReadLine());
            var heroesPower = 0;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }
            if (heroesPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
