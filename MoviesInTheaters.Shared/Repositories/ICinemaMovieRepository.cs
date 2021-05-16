using MoviesInTheaters.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Repositories
{
    public interface ICinemaMovieRepository: IRepository<CinemaMovie>
    {
        Task<CinemaMovie> DeleteCinemaMovie(CinemaMovie cinemaMovie);
        Task<IEnumerable<CinemaMovie>> GetCinemaMovieList();
        Task<IEnumerable<CinemaMovie>> GetActiveCinemaMovieList();

    }
}
