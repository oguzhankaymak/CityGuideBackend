namespace Core.DataAccess.Abstract
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IEntityRepository<T>
    {
        List<T> GetList(Expression<Func<T,bool>> filter = null);

        T Get(Expression<Func<T,bool>> filter);

        T GetInclude(int id, Expression<Func<T,object>>[] includes);
        void Add(T entity);

        void Update (T entity);

        void Delete(T entity);
    }
}