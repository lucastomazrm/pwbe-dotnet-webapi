using System;
using PWBE.TeamAthlete.DataAccess;

namespace PWBE.TeamAthlete.Services
{
    public abstract class Service : IDisposable
    {
        protected MainContext context;

        public Service(MainContext context)
        {
            this.context = context;
        }

        public Service()
        {
            this.context = new MainContext();
        }

        public virtual void Dispose()
        {
            this.context = null;
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
