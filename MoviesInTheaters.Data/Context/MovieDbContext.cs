using Microsoft.EntityFrameworkCore;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Data.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Cinema> Cinema { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var statusConverter = EntityStatus.FluentInitAndSeed(modelBuilder);
            var movieTypeConverter = MovieType.FluentInitAndSeed(modelBuilder);
            var movieDurationTypeConverter = MovieDurationType.FluentInitAndSeed(modelBuilder);

            Entities.Movie.FluentInitAndSeed(modelBuilder, statusConverter, movieTypeConverter, movieDurationTypeConverter);
            Entities.Cinema.FluentInitAndSeed(modelBuilder, statusConverter);
            Entities.CinemaMovie.FluentInitAndSeed(modelBuilder, statusConverter);

        }
    }
}
