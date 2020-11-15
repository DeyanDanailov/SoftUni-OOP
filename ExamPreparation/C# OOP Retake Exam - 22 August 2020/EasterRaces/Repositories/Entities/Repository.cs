
using System;
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> models;
        public Repository()
        {       
            this.models = new List<T>();
        }
        //public ICollection<T> models { get; protected set; }
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection <T>)this.models;
        }

        public virtual T GetByName(string name)
        {
            var type = typeof(T);
            var modelProperty = type.GetProperty("Name");
            foreach (var model in this.models)
            {
                string modelValue = (string)modelProperty?.GetValue(model);
                if (modelValue == name)
                {
                    return model;
                }
            }
            throw new Exception(String.Format(ExceptionMessages.CarNotFound, name));
        }
        
            
        
                   
        public bool Remove(T model)
        {
            if (this.models.Contains(model))
            {
                this.models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
