using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
	public class BookImageRepository : GenericRepository<BookImage>, IBookImageRepository
	{
		public BookImageRepository(AppDbContext context) : base(context)
		{
		}
	}
}
