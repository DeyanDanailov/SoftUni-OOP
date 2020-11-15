using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public class DriverRepository<IDriver> : Repository<IDriver>
    {
        //public override IDriver GetByName(string name)
        //{
        //    var type = typeof(IDriver);
        //    var modelProperty = type.GetProperty("Name");
        //    foreach (var car in this.models)
        //    {
        //        string modelValue = (string)modelProperty?.GetValue(car);
        //        if (modelValue == name)
        //        {
        //            return car;
        //        }
        //    }
        //    throw new Exception(String.Format(ExceptionMessages.DriverNotFound, name));
        //}
    }
}
