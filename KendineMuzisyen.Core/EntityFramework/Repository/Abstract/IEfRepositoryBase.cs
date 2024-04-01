using KendineMuzisyen.Core.Base;
using System.Linq.Expressions;

namespace KendineMuzisyen.Core.EntityFramework.Repository.Abstract
{
    public interface IEfRepositoryBase<TEntity>
         where TEntity : class, IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetByFilter(Expression<Func<TEntity, bool>> filter);
    }
}
