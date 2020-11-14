
using System.Collections.Generic;
using System.Linq;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories.Entities
{
    public class Repository<T> : IRepository<T>
    {
        private ICollection<T> models;
        public void Add(T model)
        {
            this.models.Add(model);
        }

        public System.Collections.Generic.IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection < T >) models;
        }

        public T GetByName(string name)
        {
            return this.models.Where(m => m.GetType().Name == name).FirstOrDefault();
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
