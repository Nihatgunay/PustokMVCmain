using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return expression is not null ? query.Where(expression) : query;
        }

        public async Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (includes.Length > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }

            return expression is not null ?
                await query.Where(expression).FirstOrDefaultAsync() :
                await query.FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdAsync(int? id, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if(includes.Length  > 0)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
