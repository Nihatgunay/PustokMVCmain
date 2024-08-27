using System.Linq.Expressions;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.Business.Services.Interfaces
{
    public interface IGenreService
    {
        Task CreateAsync(CreateGenreVM genreVM);
        Task UpdateAsync(int id, UpdateGenreVM genreVM);
        Task<Genre> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<ICollection<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression);
    }
}
