using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
	public class SlideRepository : GenericRepository<Slide>, ISlideRepository
	{
		public SlideRepository(AppDbContext context) : base(context) { }
	}
}
