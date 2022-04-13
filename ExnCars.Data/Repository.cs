using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Data
{
    public class Repository<T> : IRepository<T>
        where T :class
    {
        private readonly ExnCarsContext context;
        private readonly DbSet<T> dbSet;

        public Repository(ExnCarsContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }


        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T? GetById(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> Query(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
        public List<T> GetAll()
        {
            return dbSet.ToList();
        }
    }
}
