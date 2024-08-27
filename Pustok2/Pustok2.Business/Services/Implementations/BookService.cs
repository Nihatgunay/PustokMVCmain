using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.Business.Services.Implementations
{
	public class BookService : IBookService
	{
		public Task CreateAsync(CreateBookVM vm)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<ICollection<Book>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Book> GetByIdAsync(int? id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(int? id, UpdateBookVM vm)
		{
			throw new NotImplementedException();
		}
	}
}
