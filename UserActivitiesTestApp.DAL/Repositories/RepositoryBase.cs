using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UserActivitiesTestApp.Contractors.DAL;
using UserActivitiesTestApp.Domain.Entities;

namespace UserActivitiesTestApp.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected ApplicationDbContext _context;
        private DbSet<TEntity> _entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            try
            {
                _entities = _context.Set<TEntity>();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> where, params string[] includes)
        {
            try
            {
                return await GetQuery(includes).Where(where).CountAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _entities.Attach(entity);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where, params string[] includes)
        {
            try
            {
                return await GetQuery(includes).Where(where).AnyAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> where, params string[] includes)
        {
            try
            {
                return await GetQuery(includes).Where(where).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public TEntity GetById(Guid id)
        {
            try
            {
                return _entities.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                return await _entities.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IQueryable<TEntity> GetQuery(params string[] includes)
        {
            try
            {
                var query = _entities.AsQueryable();
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
                return query;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Guid> InsertAsync(TEntity entity)
        {
            try
            {
                entity.Id = Guid.NewGuid();
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<ICollection<TEntity>> TopAsync(int topElements)
        {
            try
            {
                return await _entities.Take(topElements).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(TEntity entity)
        {
            try
            {
                var attachedEntity = await _entities.FindAsync(entity.Id);
                if (attachedEntity != null)
                {
                    var attachedEntry = _context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
