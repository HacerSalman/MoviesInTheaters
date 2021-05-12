using MoviesInTheaters.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Shared.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICinemaRepository Cinemas { get; }
        IMovieRepository Movies { get; }
        Task<int> CommitAsync();
    }
}
