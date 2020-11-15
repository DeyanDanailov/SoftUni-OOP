
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> odels
        public Repository()
        {       
            this.models = new List<T>();
        }
        public ICollection<T> models { get; protected set; }
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection <T>)this.models;
        }

        public abstract T GetByName(string name);
        
            
        
                   
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
