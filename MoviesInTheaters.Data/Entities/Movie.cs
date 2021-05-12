using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MoviesInTheaters.Data.Entities
{
    [Table("movie")]
    public class Movie:BaseEntity
    {
        [Column("description")]
        [StringLength(2048)]
        public string Description { get; set; }

        [Column("type", TypeName = "VARCHAR(64)")]
        public MovieType.Values Type { get; set; }

        [Column("rating")]
        public double Rating { get; set; }

        [Column("name")]
        [StringLength(512)]
        [Required]
        public string Name { get; set; }

        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter, EnumToStringConverter<MovieType.Values> typeConverter)
        {
            FluentInit<Movie>(modelBuilder, statusConverter);
            modelBuilder.Entity<Movie>(entity =>
            {               
                entity.Property(e => e.Type).HasConversion(typeConverter);
                entity.HasOne<MovieType>().WithMany().HasForeignKey(s => s.Type).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => e.Name);
                entity.HasIndex(e => e.Rating);
            });
        }
    }
}
