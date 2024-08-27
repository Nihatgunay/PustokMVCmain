using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pustok2.Business.Services.Implementations;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Data.DAL;

namespace Pustok2.Business
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services, string connectionstring)
        {
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ISlideService, SlideService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();


			services.AddDbContext<AppDbContext>(op =>
            {
                op.UseSqlServer(connectionstring);
            });
        }
    }
}
