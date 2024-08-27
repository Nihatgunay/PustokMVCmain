using Microsoft.AspNetCore.Mvc;
using Pustok2.Business.Exceptions.GenreExceptions;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreController : Controller
    {
		private readonly IGenreService _service;

		public GenreController(IGenreService service)
        {
			_service = service;
		}
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync(null));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGenreVM genreVM)
        {
            if(!ModelState.IsValid)
            {
                return View(genreVM);
            }

            try
            {
				await _service.CreateAsync(genreVM);
			}
            catch(GenreExistsException ex)
            {
				ModelState.AddModelError(ex.PropName, ex.Message);
				return View(genreVM);
			}
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(genreVM);
            }
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var data = await _service.GetByIdAsync(id);

            if (data == null) throw new NullReferenceException();

            var genrevm = new UpdateGenreVM
            {
                Name = data.Name,
            };

            return View(genrevm);
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, UpdateGenreVM genreVM)
		{
			if (!ModelState.IsValid)
			{
				return View(genreVM);
			}

			try
			{
				await _service.UpdateAsync(id, genreVM);
			}
			catch (GenreExistsException ex)
			{
				ModelState.AddModelError(ex.PropName, ex.Message);
				return View(genreVM);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
				return View(genreVM);
			}

			return RedirectToAction("Index");
		}

        public async Task<IActionResult> Delete(int id)
        {
			var data = await _service.GetByIdAsync(id);

			if (data == null) throw new NullReferenceException();

            await _service.DeleteAsync(id);
			return RedirectToAction("Index");
		}
	}
}
