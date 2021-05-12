using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoviesInTheaters.Data.Entities
{
    [Table("cinema_movie")]
    public class CinemaMovie:BaseEntity
    {
        [Column("price")]
        public double Price { get; set; }

        [Column("discount_price")]
        public double DiscountPrice { get; set; }

        [Column("cinema_id")]
        public long CinemaId { get; set; }

        public Cinema Cinema { get; set; }

        [Column("movie_id")]
        public long MovieId { get; set; }

        public Movie Movie { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<CinemaMovie>(modelBuilder, statusConverter);
            modelBuilder.Entity<CinemaMovie>(entity =>
            {
                entity.HasOne(e => e.Cinema).WithMany().HasForeignKey(c => c.CinemaId).HasPrincipalKey(s => s.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Movie).WithMany().HasForeignKey(c => c.MovieId).HasPrincipalKey(s => s.Id).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => e.Price);

            });
        }
    }
}
