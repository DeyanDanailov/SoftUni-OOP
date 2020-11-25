
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository<ICar> : Repository<ICar>
    {
        private readonly ICollection<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}
