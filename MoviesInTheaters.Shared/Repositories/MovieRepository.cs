using MoviesInTheaters.Data.Context;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieDbContext context)
       : base(context)
        {
        }

        public async Task<Movie> DeleteMovie(Movie movie)
        {
            movie.Status = EntityStatus.Values.DELETED;
            return await Task.FromResult(movie);
        }
    }
}
