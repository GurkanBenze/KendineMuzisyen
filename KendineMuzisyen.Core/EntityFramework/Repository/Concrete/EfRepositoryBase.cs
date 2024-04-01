using KendineMuzisyen.Core.Base;
using KendineMuzisyen.Core.EntityFramework.Repository.Abstract;
using System.Data.Entity;
using System.Linq.Expressions;

namespace KendineMuzisyen.Core.EntityFramework.Repository.Concrete
{
    public class EfRepositoryBase<TEntity, TContext> : IEfRepositoryBase<TEntity>
       where TEntity : class, IEntity
       where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                var result = context.Set<TEntity>().FirstOrDefault(filter);
                return result;
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //IList<TEntity> result;
                //if (filter == null)
                //{
                //    result = context.Set<TEntity>().ToList();
                //}
                //else
                //{
                //    result = context.Set<TEntity>().Where(filter).ToList();
                //}

                var result = filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();

                return result;
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
