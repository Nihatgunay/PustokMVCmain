using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.Utilities.Extensions;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class BookController : Controller
{
	private readonly IGenreService _genreService;
	private readonly IAuthorService _authorService;
	private readonly IWebHostEnvironment _env;
    private readonly IBookRepository _bookRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookImageRepository _bookImageRepository;

    public BookController(IGenreService genreService, IAuthorService authorService,
							IWebHostEnvironment env, IBookRepository bookRepository,
							IGenreRepository genreRepository, IAuthorRepository authorRepository,
                            IBookImageRepository bookImageRepository)
	{
		_genreService = genreService;
		_authorService = authorService;
		_env = env;
        _bookRepository = bookRepository;
        _genreRepository = genreRepository;
        _authorRepository = authorRepository;
        _bookImageRepository = bookImageRepository;
    }

	public async Task<IActionResult> Index()
	{
		var books = await _bookRepository.Table
									  .Include(b => b.Genre)
									  .Include(b => b.Author)
									  .Where(b => !b.IsDeleted)
									  .ToListAsync();
		return View(books);
	}

	public async Task<IActionResult> Create()
	{
		ViewBag.Genres = await _genreService.GetAllAsync(x => !x.IsDeleted);
		ViewBag.Authors = await _authorService.GetAllAsync(x => !x.IsDeleted);

		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Create(CreateBookVM vm)
	{
		ViewBag.Genres = await _genreService.GetAllAsync(x => !x.IsDeleted);
		ViewBag.Authors = await _authorService.GetAllAsync(x => !x.IsDeleted);

		if (!ModelState.IsValid) return View(vm);

		if(await _genreRepository.Table.AllAsync(x => x.Id != vm.GenreId))
		{
			ModelState.AddModelError("GenreId", "Genre not found");
			return View();
		}

        if (await _authorRepository.Table.AllAsync(x => x.Id != vm.AuthorId))
        {
            ModelState.AddModelError("AuthorId", "author not found");
            return View();
        }

        Book book = new Book()
        {
            Title = vm.Title,
            Description = vm.Description,
            StockCount = vm.StockCount,
            CostPrice = vm.CostPrice,
            SalePercent = vm.SalePercent,
            SalePrice = vm.SalePrice,
            IsAvailable = vm.IsAvailable,
            Code = vm.Code,
            AuthorId = vm.AuthorId,
            GenreId = vm.GenreId,
        };

        if (vm.PosterImage is not null)
		{
			if (vm.PosterImage.ContentType != "image/jpeg" && vm.PosterImage.ContentType != "image/png")
			{
				ModelState.AddModelError("PosterImage", "posterimage type must be png, jpeg");
				return View();
			}
			if (vm.PosterImage.Length > 2097152)
			{
				ModelState.AddModelError("PosterImage", "posterimage size must be <= 2mb");
				return View();
			}

			BookImage bookImage = new BookImage()
			{
                ImageUrl = vm.PosterImage.CreateFileAsync(_env.WebRootPath, "uploads/books"),
				Createdtime = DateTime.Now,
				Updatedtime = DateTime.Now,
				IsDeleted = false,
				IsPrimary = true,
				Book = book
			};

            await _bookImageRepository.CreateAsync(bookImage);
        }

        if (vm.HoverImage is not null)
        {
            if (vm.HoverImage.ContentType != "image/jpeg" && vm.HoverImage.ContentType != "image/png")
            {
                ModelState.AddModelError("HoverImage", "posterimage type must be png, jpeg");
                return View();
            }
            if (vm.HoverImage.Length > 2097152)
            {
                ModelState.AddModelError("HoverImage", "posterimage size must be <= 2mb");
                return View();
            }

            BookImage bookImage = new BookImage()
            {
                ImageUrl = vm.HoverImage.CreateFileAsync(_env.WebRootPath, "uploads/books"),
                Createdtime = DateTime.Now,
                Updatedtime = DateTime.Now,
                IsDeleted = false,
                IsPrimary = false,
                Book = book
            };

            await _bookImageRepository.CreateAsync(bookImage);
        }

        if (vm.Images.Count > 0)
        {
			foreach (var img in vm.Images)
			{
                if (img.ContentType != "image/jpeg" && img.ContentType != "image/png")
                {
                    ModelState.AddModelError("Images", "posterimage type must be png, jpeg");
                    return View();
                }
                if (img.Length > 2097152)
                {
                    ModelState.AddModelError("Images", "posterimage size must be <= 2mb");
                    return View();
                }

                BookImage bookImage = new BookImage()
                {
                    ImageUrl = vm.HoverImage.CreateFileAsync(_env.WebRootPath, "uploads/books"),
                    Createdtime = DateTime.Now,
                    Updatedtime = DateTime.Now,
                    IsDeleted = false,
                    IsPrimary = null,
                    Book = book
                };

                await _bookImageRepository.CreateAsync(bookImage);
            }
        }

		

		await _bookRepository.CreateAsync(book);
		await _bookRepository.CommitAsync();

        return RedirectToAction(nameof(Index));
	}
}


