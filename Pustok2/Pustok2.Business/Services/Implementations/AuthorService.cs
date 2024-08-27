using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Exceptions.AuthorExceptions;
using Pustok2.Business.Exceptions.CommonExceptions;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels.Author;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.Business.Services.Implementations
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepository _authorRepository;

		public AuthorService(IAuthorRepository authorRepository)
        {
			_authorRepository = authorRepository;
		}
        public async Task CreateAsync(CreateAuthorVM vm)
		{
			if (string.IsNullOrEmpty(vm.FullName))
			{
				throw new AuthorNameException("author fullname cant be null");
			}

			var data = new Author()
			{
				FullName = vm.FullName,
				Updatedtime = DateTime.Now,
				Createdtime = DateTime.Now,
				IsDeleted = false
			};

			await _authorRepository.CreateAsync(data);
			await _authorRepository.CommitAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var data = await _authorRepository.GetByIdAsync(id);

			if(data is null)
			{
				throw new EntityNotFoundException("Author not found");
			}

			_authorRepository.Delete(data);
			await _authorRepository.CommitAsync();
		}

		public async Task<ICollection<Author>> GetAllAsync(Expression<Func<Author, bool>> expression)
		{
			return await _authorRepository.GetAll(expression).ToListAsync();
		}

		public async Task<Author> GetByIdAsync(int? id)
		{
			if (id <= 0 || id is null)
			{
				throw new IdIsNotValidException("Id isnt valid");
			}

			return await _authorRepository.GetByIdAsync(id);
		}

		public async Task UpdateAsync(int? id, UpdateAuthorVM vm)
		{
			if(id <= 0 || id is null)
			{
				throw new IdIsNotValidException("Id isnt valid");
			}

			if (string.IsNullOrEmpty(vm.FullName))
			{
				throw new AuthorNameException("author fullname cant be null");
			}

			var data = await _authorRepository.GetByIdAsync(id);

			if (data is null)
			{
				throw new EntityNotFoundException("Author not found");
			}

			data.FullName = vm.FullName;
			data.Updatedtime = DateTime.Now;

			await _authorRepository.CommitAsync();
		}
	}
}
