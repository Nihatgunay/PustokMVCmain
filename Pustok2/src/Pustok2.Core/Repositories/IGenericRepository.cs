using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pustok2.Core.Models;

namespace Pustok2.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int? id, params string[] includes);
        Task<TEntity> GetByExpressionAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression, params string[] includes);
        void Delete(TEntity entity);
        Task<int> CommitAsync();
    }
}
