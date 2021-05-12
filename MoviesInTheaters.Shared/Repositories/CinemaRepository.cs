using MoviesInTheaters.Data.Context;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public class CinemaRepository : Repository<Cinema>, ICinemaRepository
    {
        public CinemaRepository(MovieDbContext context)
          : base(context)
        {
        }

        public async Task<Cinema> DeleteCinema(Cinema cinema)
        {
            cinema.Status = EntityStatus.Values.DELETED;
            return await Task.FromResult(cinema);
        }

    }
}
