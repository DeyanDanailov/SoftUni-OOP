﻿
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;

using System.Collections.Generic;


namespace EasterRaces.Repositories.Entities
{
    public class CarRepository : Repository<ICar>
    {
        private readonly ICollection<ICar> cars;
        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
    }
}
