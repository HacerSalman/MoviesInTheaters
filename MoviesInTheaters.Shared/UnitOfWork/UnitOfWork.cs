using MoviesInTheaters.Data.Context;
using MoviesInTheaters.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieDbContext _context;
        private CinemaRepository _cinemaRepository;
        private MovieRepository _movieRepository;
        private CinemaMovieRepository _cinemaMovieRepository;

        public UnitOfWork(MovieDbContext context)
        {
            this._context = context;
        }
        public IMovieRepository Movies => _movieRepository = _movieRepository ?? new MovieRepository(_context);

        public ICinemaRepository Cinemas => _cinemaRepository = _cinemaRepository ?? new CinemaRepository(_context);
        public ICinemaMovieRepository CinemaMovies => _cinemaMovieRepository = _cinemaMovieRepository ?? new CinemaMovieRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
