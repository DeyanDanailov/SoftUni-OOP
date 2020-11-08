
using Raiding.Common;
using System;
using Raiding.Models;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public BaseHero ProduceHero(string type, string name)
        {
            BaseHero baseHero = null;
            int power = 0;
            switch (type)
            {
                case "Druid":
                    power = 80;
                    baseHero = new Druid(name, power);
                    break;
                case "Paladin":
                    power = 100;
                    baseHero = new Paladin(name, power);
                    break;
                case "Rogue":
                    power = 80;
                    baseHero = new Rogue(name, power);
                    break;
                case "Warrior":
                    power = 100;
                    baseHero = new Warrior(name, power);
                    break;
                default:
                    throw new ArgumentException(ExceptionMessages.INVALID_HERO_EXCEPTION);                    
            }
            return baseHero;
        }
    }
}
