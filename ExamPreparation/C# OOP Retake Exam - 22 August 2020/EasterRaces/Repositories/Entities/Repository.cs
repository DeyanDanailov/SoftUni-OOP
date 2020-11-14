
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected ICollection<T> Models;
        public Repository()
        {       
            this.Models = new List<T>();
        }

        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection <T>)this.Models;
        }

        public T GetByName(string name);
                   
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
