using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Repositry
{
    public interface IRepositry<T,ID> where T:class
    {
        IEnumerable<T> GetAll();

        T Get(ID id);

        void Add(T entity);

        void Edit(T entity);

        void Delete(T entity);

        int SaveAll();

    }
}
