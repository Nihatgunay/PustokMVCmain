using Microsoft.AspNetCore.Mvc;
using Pustok2.Business.Services.Interfaces;
using Pustok2.MVC.ViewModels;

namespace Pustok2.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISlideService _slideService;

        public HomeController(ISlideService slideService)
        {
            _slideService = slideService;
        }

        public async Task<IActionResult> Index()
        {
            var slides = await _slideService.GetAllAsync();

            var homeVM = new HomeVM
            {
                Slides = slides.ToList()
            };

            return View(homeVM);
        }
    }
}
