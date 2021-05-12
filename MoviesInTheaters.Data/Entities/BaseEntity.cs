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
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }       

        [Column("status", TypeName = "VARCHAR(32)")]
        [Display(Name = "STATUS")]
        public EntityStatus.Values Status { get; set; }

        [Column("create_time")]
        public long CreateTime { get; set; }

        [Column("Update_time")]
        public long UpdateTime { get; set; }

        [Column("owner")]
        public string Owner { get; set; }

        [Column("modifier")]
        public string Modifier { get; set; }
        internal static void FluentInit<T>(ModelBuilder modelBuilder, EnumToStringConverter<EntityStatus.Values> statusConverter) where T : BaseEntity
        {
            modelBuilder.Entity<T>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Status).HasConversion(statusConverter);
                entity.HasOne<EntityStatus>().WithMany().HasForeignKey(s => s.Status).OnDelete(DeleteBehavior.Restrict);
                entity.HasIndex(e => e.CreateTime);
                entity.HasIndex(e => e.UpdateTime);              

            });
        }
    }
}
