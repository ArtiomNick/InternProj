using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repository.Interfaces
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        IList<T> GetAll();

        T GetById(long id);

        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);

        void Save();

    }
}
