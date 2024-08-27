using Pustok2.Business.ViewModels.Author;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.Business.Services.Interfaces
{
	public interface IBookService
	{
		Task CreateAsync(CreateBookVM vm);
		Task UpdateAsync(int? id, UpdateBookVM vm);
		Task<Book> GetByIdAsync(int? id);
		Task DeleteAsync(int id);
		Task<ICollection<Book>> GetAllAsync();
	}
}
