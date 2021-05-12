using MoviesInTheaters.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public interface IMovieRepository: IRepository<Movie>
    {
        Task<Movie> DeleteMovie(Movie movie);
    }
}
