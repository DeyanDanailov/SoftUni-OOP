

using System;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class RaceRepository<IRace> : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var type = typeof(IRace);
            var modelProperty = type.GetProperty("Name");
            foreach (var car in this.models)
            {
                string modelValue = (string)modelProperty.GetValue(car);
                if (modelValue == name)
                {
                    return car;
                }
            }
            throw new Exception(String.Format(ExceptionMessages.DriverNotFound, name));
        }
    }
}
