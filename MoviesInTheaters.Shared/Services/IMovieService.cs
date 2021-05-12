using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<IEnumerable<Movie>> GetActiveMovies();
        Task<IEnumerable<Movie>> GetMoviesByName(string name);
        Task<Movie> GetMovieById(int id);
        Task<Movie> CreateMovie(Movie newMovie);
        Task UpdateMovie(Movie MovieToBeUpdated, Movie Movie);
        Task<Movie> DeleteMovie(Movie Movie);
    }
}
