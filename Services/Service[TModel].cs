using System.Collections.Generic;
using PWBE.TeamAthlete.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PWBE.TeamAthlete.Services
{
    public abstract class Services<T> : Service where T : class
    {
        public Services(MainContext context)
            : base(context)
        {
        }

        public Services()
            : base()
        {
        }

        public IEnumerable<T> All()
        {
            var query = this.context.Set<T>().AsQueryable();
            foreach (var property in this.context.Model.FindEntityType(typeof(T)).GetNavigations())
            {
                query = query.Include(property.Name);
            }
            return query;
        }

        public void Save(T item)
        {
            this.context.Set<T>().Add(item);
            base.Save();
        }

        public void Save(IEnumerable<T> items)
        {
            this.context.Set<T>().AddRange(items);
            base.Save();
        }

        public void Update(T item)
        {
            this.context.Set<T>().Attach(item);
            this.context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            base.Save();
        }

        public void Delete(object id)
        {
            var item = this.Get(id);
            this.context.Set<T>().Remove(item);
            base.Save();
        }

        public T Get(object id)
        {
            return base.context.Set<T>().Find(id);
        }
    }
}