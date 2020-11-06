using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Infractracure.Data
{
   public class BaseRepository<TEntity> where TEntity:class
    {
        internal WindowsDatabaseContext context;
        internal DbSet<TEntity> dbSet;

        public BaseRepository(WindowsDatabaseContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get()
        {
            return dbSet.AsEnumerable();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Create(TEntity entity)
        {
            dbSet.Add(entity);
            SaveChanges();
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);

        }

        public virtual void Delete(TEntity entity)
        {
            if(context.Entry(entity).State== EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
            SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
