using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Data.Context
{
    public class MovieDbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
    {
        public MovieDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
            optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MOVIE_APP_DB_CONNECTION"));
            optionsBuilder.EnableSensitiveDataLogging();

            return new MovieDbContext(optionsBuilder.Options);
        }
    }
}
