using Pustok2.Core.Models;
using Pustok2.Core.Repositories;
using Pustok2.Data.DAL;

namespace Pustok2.Data.Repositories
{
    public class GenreRepository : GenericRepository<Genre> ,IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context) { } 
    }
}
