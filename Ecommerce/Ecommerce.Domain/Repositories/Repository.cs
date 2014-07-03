using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ECOMMERCEEntities db;
        internal DbSet<TEntity> dbSet;

        public Repository(ECOMMERCEEntities db)
        {
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }
        public virtual IQueryable<TEntity> Get(string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(TEntity entity)
        {
            dbSet.Attach(entity);
            db.Entry(entity).State = EntityState.Deleted;
        }
        public virtual void RawQuery(string query)
        {
            db.Database.ExecuteSqlCommand(query);
        }
    }
}
