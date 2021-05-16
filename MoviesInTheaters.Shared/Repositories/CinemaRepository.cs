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

        public async Task<List<Cinema>> GetCinemasByName(string name)
        {
            try
            {
                return await Context.Cinemas.AsNoTracking().Where(_ => _.Name.Contains(name) && _.Status == EntityStatus.Values.ACTIVE).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
