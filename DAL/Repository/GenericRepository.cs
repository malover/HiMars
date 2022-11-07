using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal WarehouseContext context;
        internal DbSet<TEntity> dbset;
        public GenericRepository(WarehouseContext context)
        {
            this.context = context;
            this.dbset = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return dbset;
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbset.Find(id);
        }

        public virtual void Add(TEntity entity)
        {
            dbset.Add(entity);
        }

        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = dbset.Find(id);
            dbset.Remove(entityToDelete);
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            dbset.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
