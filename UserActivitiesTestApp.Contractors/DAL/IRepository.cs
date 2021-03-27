using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.Contractors.DAL
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQuery(params string[] includes);
        Task<ICollection<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> where, params string[] includes);
        Task<TEntity> GetByIdAsync(Guid id);
        TEntity GetById(Guid id);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<Guid> InsertAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Delete(Guid id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where, params string[] includes);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> where, params string[] includes);
        Task<ICollection<TEntity>> TopAsync(int topElements);
    }

}
