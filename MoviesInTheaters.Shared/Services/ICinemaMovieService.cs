using MoviesInTheaters.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Services
{
    public interface ICinemaMovieService
    {
        Task<IEnumerable<CinemaMovie>> GetCinemaMovieList();
        Task<IEnumerable<CinemaMovie>> GetActiveCinemaMovieList();
        Task<CinemaMovie> GetCinemaMovieById(long id);
        Task<CinemaMovie> CreateCinemaMovie(CinemaMovie newCinemaMovie);
        Task<CinemaMovie> UpdateCinemaMovie(CinemaMovie cinemaMovie);
        Task<CinemaMovie> DeleteCinemaMovie(CinemaMovie cinemaMovie);
    }
}
