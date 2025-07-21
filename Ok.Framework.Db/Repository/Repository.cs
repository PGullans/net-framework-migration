using Ok.Framework.Db.Model;

using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Ok.Framework.Db.Repository
{
    public class Repository<T> : IRepository<T> where T : DbModel
    {
        private readonly OkFrameworkContext _dbContext;
        private DbSet<T> _entities;

        public Repository(OkFrameworkContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _dbContext.Set<T>();
                }
                return _entities;
            }
        }

        public T GetById(object Id)
        {
            return Id == null ? null : Entities.Find(Id);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> whereExpression = null)
        {
            if (whereExpression != null)
                return Entities.Where(whereExpression);
            return Entities;
        }

        public IQueryable<T> GetAllAsNoTracking(Expression<Func<T, bool>> whereExpression = null)
        {
            if (whereExpression != null)
                return Entities.Where(whereExpression).AsNoTracking();
            return Entities.AsNoTracking();
        }

        public void Insert(T entity)
        {
            if (entity == null) ThrowArgumentException();

            Entities.Add(entity);

            _dbContext.SaveChanges();
        }

        public bool Update(T entity)
        {
            if (entity == null) ThrowArgumentException();

            if (_dbContext.Entry(entity).State == EntityState.Detached) // && Entities.All(e => e.Id != entity.Id))
                Entities.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return _dbContext.SaveChanges() > 0;
        }

        private static void ThrowArgumentException()
        {
            throw new ArgumentException("The parameter cannot be null!", "entity");
        }
    }
}
