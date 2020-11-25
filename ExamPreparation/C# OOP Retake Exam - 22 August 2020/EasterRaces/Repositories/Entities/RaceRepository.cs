

using System;
using System.Collections.Generic;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository<IRace> : Repository<IRace>
    {
        private readonly ICollection<IRace> races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
    }
}
