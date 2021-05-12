using MoviesInTheaters.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinemasInTheaters.Shared.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetAllCinemas();
        Task<IEnumerable<Cinema>> GetActiveCinemas();
        Task<Cinema> GetCinemaById(long id);
        Task<IEnumerable<Cinema>> GetCinemasByName(string name);
        Task<Cinema> CreateCinema(Cinema newCinema);
        Cinema UpdateCinema(Cinema Cinema);
        Task<Cinema> DeleteCinema(Cinema Cinema);
    }
}
