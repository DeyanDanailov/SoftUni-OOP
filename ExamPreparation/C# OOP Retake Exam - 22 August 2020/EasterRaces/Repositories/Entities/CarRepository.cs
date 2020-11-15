
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasterRaces.Repositories.Entities
{
    public class CarRepository<ICar> : Repository<ICar>
    {
        public override ICar GetByName(string name)
        {
            //var list = new List<ICar>(this.Models);
            var type = typeof(Car);
            var modelProperty = type.GetProperty("Model");
            foreach (var car in this.models)
            {
                string modelValue = (string)modelProperty.GetValue(car);
                if (modelValue == name)
                {
                    return car;
                }
            }
            throw new Exception(String.Format(ExceptionMessages.CarNotFound, name));
        }
    }
}
