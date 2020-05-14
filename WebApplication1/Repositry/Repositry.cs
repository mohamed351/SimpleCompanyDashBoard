using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class Repositry<T,ID> : IRepositry<T,ID> where T : class
    {
        public Repositry(CompanyContext company)
        {
            Company = company;
        }

        public CompanyContext Company { get; }

        public void Add(T entity)
        {
            Company.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Company.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            Company.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public T Get(ID id)
        {
            return Company.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Company.Set<T>().ToList();
        }

        public int SaveAll()
        {
            return Company.SaveChanges();
        }
    }
}
