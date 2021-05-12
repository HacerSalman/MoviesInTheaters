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
    [Table("cinema")]
    public class Cinema:BaseEntity
    {
        [Column("address")]
        [StringLength(1024)]
        public string Address { get; set; }

        [Column("name")]
        [StringLength(512)]
        [Required]
        public string Name { get; set; }
        internal static void FluentInitAndSeed(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter)
        {
            FluentInit<Cinema>(modelBuilder, statusConverter);
            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasIndex(e => e.Name);                
            });
        }
    }
}
