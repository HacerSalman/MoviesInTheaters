using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Services
{
    public class CinemaMovieService : ICinemaMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CinemaMovieService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CinemaMovie> CreateCinemaMovie(CinemaMovie newCinemaMovie)
        {
            await _unitOfWork.CinemaMovies.AddAsync(newCinemaMovie);
            await _unitOfWork.CommitAsync();
            return newCinemaMovie;
        }

        public async Task<CinemaMovie> DeleteCinemaMovie(CinemaMovie cinemaMovie)
        {
            await _unitOfWork.CinemaMovies.DeleteCinemaMovie(cinemaMovie);
            await _unitOfWork.CommitAsync();
            return cinemaMovie;
        }

        public async Task<IEnumerable<CinemaMovie>> GetActiveCinemaMovieList()
        {
            return await _unitOfWork.CinemaMovies.GetActiveCinemaMovieList();
        }

        public async Task<CinemaMovie> GetCinemaMovieById(long id)
        {
            return await _unitOfWork.CinemaMovies.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CinemaMovie>> GetCinemaMovieList()
        {
            return await _unitOfWork.CinemaMovies.GetCinemaMovieList();
        }

        public async Task<CinemaMovie> UpdateCinemaMovie(CinemaMovie cinemaMovie)
        {
            await _unitOfWork.CinemaMovies.Update(cinemaMovie);
            await _unitOfWork.CommitAsync();
            return cinemaMovie;
        }
    }
}
