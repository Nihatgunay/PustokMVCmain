using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Services.Implementations;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SlideController : Controller
	{
		private readonly ISlideService _service;

		public SlideController(ISlideService slideService)
		{
			_service = slideService;
		}

		public async Task<IActionResult> Index()
		{
			var slides = await _service.GetAllAsync();
			return View(slides);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateSlideVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			await _service.CreateAsync(vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int id)
		{
			var slide = await _service.GetByIdAsync(id);
			if (slide == null)
			{
				return NotFound();
			}

			var updateVM = new UpdateSlideVM
			{
				Title = slide.Title,
				Subtitle = slide.Subtitle,
				ImageUrl = slide.ImageUrl
			};

			return View(updateVM);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(int id, UpdateSlideVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			await _service.UpdateAsync(id, vm);

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}


	}
}
