using System;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository<Driver> : Repository<Driver>
    {
        public override Driver GetByName(string name)
        {
            foreach (var item in this.Models)
            {
                if (item.Name == name)
                {

                }
            }
        }
    }
}
