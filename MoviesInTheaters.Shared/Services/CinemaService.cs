using CinemasInTheaters.Shared.Services;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CinemaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Cinema> CreateCinema(Cinema newCinema)
        {
            await _unitOfWork.Cinemas.AddAsync(newCinema);
            await _unitOfWork.CommitAsync();
            return newCinema;
        }

        public async Task<Cinema> DeleteCinema(Cinema cinema)
        {
             await _unitOfWork.Cinemas.DeleteCinema(cinema);
            await _unitOfWork.CommitAsync();
            return cinema;
        }

        public async Task<IEnumerable<Cinema>> GetActiveCinemas()
        {
          return  await Task.FromResult( _unitOfWork.Cinemas.Find(_ => _.Status == EntityStatus.Values.ACTIVE));
        }

        public async Task<IEnumerable<Cinema>> GetAllCinemas()
        {
            return await _unitOfWork.Cinemas.GetAllAsync();
        }

        public async Task<Cinema> GetCinemaById(long id)
        {
            return await _unitOfWork.Cinemas.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cinema>> GetCinemasByName(string name)
        {
            return await Task.FromResult(_unitOfWork.Cinemas.Find(_ => _.Name.Contains(name)));
        }

        public async Task<Cinema> UpdateCinema(Cinema Cinema)
        {
            await _unitOfWork.Cinemas.Update(Cinema);
            await _unitOfWork.CommitAsync();
            return Cinema;
        }
    }
}
