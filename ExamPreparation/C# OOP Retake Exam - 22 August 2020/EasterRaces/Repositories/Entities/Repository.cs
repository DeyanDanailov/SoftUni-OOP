
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
       
        public Repository()
        {       
            this.Models = new List<T>();
        }
        public ICollection<T> Models { get; protected set; }
        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection <T>)this.Models;
        }

        public abstract T GetByName(string name);
        
            
        
                   
        public bool Remove(T model)
        {
            if (this.Models.Contains(model))
            {
                this.Models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
