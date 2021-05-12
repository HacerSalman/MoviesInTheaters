using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MoviesInTheaters.Data.Enums
{
    [Table("movie_type")]
    public class MovieType
    {
        [Column("v", TypeName = "VARCHAR(64)")]
        public Values V { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum Values
        {
            ACTION,
            DRAMA,
            COMEDY,
            HORROR,
            THRILLER,
            SCIENCE_FICTION,
            ADVENTURE,
            FASTASTIC,
            DETECTIVE

        }

        internal static EnumToStringConverter<Values> FluentInitAndSeed(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<Values>();
            modelBuilder.Entity<MovieType>(entity =>
            {
                entity.HasKey(e => e.V);
                entity.Property(e => e.V).HasConversion(converter);
            });
            var values = Enum.GetValues(typeof(Values)).Cast<Values>();
            foreach (var v in values)
            {
                modelBuilder.Entity<MovieType>(entity =>
                {
                    entity.HasData(new MovieType() { V = v });
                });
            }
            return converter;
        }
    }
}
