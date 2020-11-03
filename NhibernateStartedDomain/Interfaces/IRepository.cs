using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NhibernateStartedDomain.Interfaces
{
    public interface IRepository<T>
    {
        void Post(T entidade);
        void Put(T entidade);
        void Delete(T entidade);
        T Get(long id);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> where);
    }
}
