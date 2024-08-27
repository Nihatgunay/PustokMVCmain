using System;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business;
using Pustok2.Business.Services.Implementations;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Core.Repositories;
using Pustok2.Data;
using Pustok2.Data.DAL;
using Pustok2.Data.Repositories;

namespace Pustok2.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddRepositories();
            builder.Services.AddServices(builder.Configuration.GetConnectionString("Default"));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                "default",
                "{controller=home}/{action=index}/{id?}"
            );

            app.Run();
        }
    }
}
