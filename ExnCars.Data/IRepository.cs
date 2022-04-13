using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Data
{
    public interface IRepository<T>
        where T:class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T? GetById(int id);
        IQueryable<T> Query(Expression<Func<T,bool>> expression);
        List<T> GetAll();
    }
}
