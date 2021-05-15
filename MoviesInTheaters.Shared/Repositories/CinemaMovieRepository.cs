using Microsoft.EntityFrameworkCore;
using MoviesInTheaters.Data.Context;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public class CinemaMovieRepository : Repository<CinemaMovie>, ICinemaMovieRepository
    {
        public CinemaMovieRepository(MovieDbContext context)
         : base(context)
        {
        }

        public async Task<CinemaMovie> DeleteCinemaMovie(CinemaMovie cinemaMovie)
        {
            cinemaMovie.Status = EntityStatus.Values.DELETED;
            return await Task.FromResult(cinemaMovie);
        }

        public async Task<IEnumerable<CinemaMovie>> GetActiveCinemaMovieList()
        {
            return await Context.CinemaMovies.Include(_ => _.Cinema).Include(_ => _.Movie).Where(_ => _.Status == EntityStatus.Values.ACTIVE && _.Cinema.Status == EntityStatus.Values.ACTIVE && _.Movie.Status == EntityStatus.Values.ACTIVE).ToListAsync();
        }

        public async Task<IEnumerable<CinemaMovie>> GetCinemaMovieList()
        {
            return await Context.CinemaMovies.Include(_ => _.Cinema).Include(_ => _.Movie).ToListAsync();
        }
    }
}
