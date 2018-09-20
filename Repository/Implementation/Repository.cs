using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interfaces;

namespace Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        //private EmployeeManagementContext context;
        private EmployeeManagementContext context = new EmployeeManagementContext();
        public Repository(EmployeeManagementContext context)
        {
            this.context = context;
        }

        public IList<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public void Create(T entity)
        {
            var item = context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public T GetById(long id)
        {
            return context.Set<T>().SingleOrDefault(e => e.Id == id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

