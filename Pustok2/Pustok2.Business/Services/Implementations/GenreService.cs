using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Exceptions.GenreExceptions;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.Business.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(CreateGenreVM genreVM)
        {
            if(await _repository.Table.AnyAsync(x => x.Name.ToLower().Trim() == genreVM.Name.ToLower().Trim()))
            {
                throw new GenreExistsException("Name", "Genre already exissts");
			}

            var entity = new Genre()
            {
                Name = genreVM.Name,
                Createdtime = DateTime.Now,
                Updatedtime = DateTime.Now,
            };
            await _repository.CreateAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity == null)
            {
                throw new NullReferenceException();
            }
            _repository.Delete(entity);
            await _repository.CommitAsync();
        }

        public async Task<ICollection<Genre>> GetAllAsync(Expression<Func<Genre, bool>> expression)
        {
            return await _repository.GetAll(expression).ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public async Task UpdateAsync(int id, UpdateGenreVM genreVM)
        {
			if (await _repository.Table.AnyAsync(x => x.Name.ToLower().Trim() == genreVM.Name.ToLower().Trim() && x.Id != id))
			{
				throw new GenreExistsException("Name", "Genre already exissts");
			}

			var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity.Name = genreVM.Name;
            entity.Updatedtime = DateTime.Now;

            await _repository.CommitAsync();
        }
    }
}
