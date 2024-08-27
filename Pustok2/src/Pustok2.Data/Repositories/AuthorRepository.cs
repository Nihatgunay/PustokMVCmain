using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
	public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
	{
		public AuthorRepository(AppDbContext context) : base(context)
		{
		}
	}
}
