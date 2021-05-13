using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Movie> CreateMovie(Movie newMovie)
        {
            await _unitOfWork.Movies.AddAsync(newMovie);
            await _unitOfWork.CommitAsync();
            return newMovie;
        }

        public async Task<Movie> DeleteMovie(Movie movie)
        {
            await _unitOfWork.Movies.DeleteMovie(movie);
            await _unitOfWork.CommitAsync();
            return movie;
        }

        public async Task<IEnumerable<Movie>> GetActiveMovies()
        {
            return await Task.FromResult(_unitOfWork.Movies.Find(_ => _.Status == EntityStatus.Values.ACTIVE));
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _unitOfWork.Movies.GetAllAsync();
        }

        public async Task<Movie> GetMovieById(long id)
        {
            return await _unitOfWork.Movies.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetMoviesByName(string name)
        {
            return await Task.FromResult(_unitOfWork.Movies.Find(_ => _.Name.Contains(name)));
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            await _unitOfWork.Movies.Update(movie);
            await _unitOfWork.CommitAsync();
            return movie;
        }
    }
}
