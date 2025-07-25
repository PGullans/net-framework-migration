using Ok.Framework.Db.Model;

using System;
using System.Linq;
using System.Linq.Expressions;

namespace Ok.Framework.Db.Repository
{
    public interface IRepository<T> where T : DbModel
    {
            IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpression = null);
            IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> whereExpression = null);
            T GetById(object id);
            void Insert(T entity);
            bool Update(T entityToUpdate);
    }
}
