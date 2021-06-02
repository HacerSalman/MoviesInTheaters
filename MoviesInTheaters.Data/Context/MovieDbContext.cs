using Microsoft.EntityFrameworkCore;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Data.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MoviesInTheaters.Data.Context
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<CinemaMovie> CinemaMovies { get; set; }
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
      
        }

        public async Task<int> SaveChangesAsync()
        {
            string currentUsername = "anonymous";   
       
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity.GetType().IsSubclassOf(typeof(BaseEntity)))
                {
                    if (entry.State == EntityState.Added)
                    {
                        ((BaseEntity)entry.Entity).CreateTime = DateTimeUtils.GetCurrentTicks();
                        ((BaseEntity)entry.Entity).Owner = currentUsername;
                    }
                    ((BaseEntity)entry.Entity).UpdateTime = DateTimeUtils.GetCurrentTicks();
                    ((BaseEntity)entry.Entity).Modifier = currentUsername;
                }
       
            }
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var statusConverter = EntityStatus.FluentInitAndSeed(modelBuilder);
            var movieTypeConverter = MovieType.FluentInitAndSeed(modelBuilder);
            var movieDurationTypeConverter = MovieDurationType.FluentInitAndSeed(modelBuilder);

            Movie.FluentInitAndSeed(modelBuilder, statusConverter, movieTypeConverter, movieDurationTypeConverter);
            Cinema.FluentInitAndSeed(modelBuilder, statusConverter);
            CinemaMovie.FluentInitAndSeed(modelBuilder, statusConverter);

        }
    }
}
