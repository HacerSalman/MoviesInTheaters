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
        Task<List<Movie>> GetMoviesByName(string name);
        Task<Movie> GetMovieById(long id);
        Task<Movie> CreateMovie(Movie newMovie);
        Task<Movie> UpdateMovie(Movie movie);
        Task<Movie> DeleteMovie(Movie movie);
    }
}
