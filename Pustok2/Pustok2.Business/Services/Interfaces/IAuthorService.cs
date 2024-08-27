using System.Linq.Expressions;
using Pustok2.Business.ViewModels;
using Pustok2.Business.ViewModels.Author;
using Pustok2.Core.Models;

namespace Pustok2.Business.Services.Interfaces
{
	public interface IAuthorService
	{
		Task CreateAsync(CreateAuthorVM vm);
		Task UpdateAsync(int? id, UpdateAuthorVM vm);
		Task<Author> GetByIdAsync(int? id);
		Task DeleteAsync(int id);
		Task<ICollection<Author>> GetAllAsync(Expression<Func<Author, bool>> expression);
	}
}
