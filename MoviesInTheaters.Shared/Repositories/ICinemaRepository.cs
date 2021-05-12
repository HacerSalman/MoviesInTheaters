using MoviesInTheaters.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public interface ICinemaRepository: IRepository<Cinema>
    {
        Task<Cinema> DeleteCinema(Cinema cinema);

    }
}
