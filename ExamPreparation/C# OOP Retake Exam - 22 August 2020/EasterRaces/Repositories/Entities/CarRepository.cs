
using EasterRaces.Models.Cars.Entities;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository<ICar> : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            var list = new List<ICar>(this.Models);
            ICar car = list.Any(m=>m.)
            
        }
    }
}
