using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository<IDriver> : Repository<IDriver>
    {
        private readonly ICollection<IDriver> drivers;
        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
    }
}
