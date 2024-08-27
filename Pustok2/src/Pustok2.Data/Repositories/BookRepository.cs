using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
	public class BookRepository : GenericRepository<Book>, IBookRepository
	{
		public BookRepository(AppDbContext context) : base(context)
		{
		}
	}
}
