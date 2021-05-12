﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesInTheaters.Data.Context;

namespace MoviesInTheaters.Data.Migrations
{
    [DbContext(typeof(MovieDbContext))]
    partial class MovieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.Cinema", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnName("address")
                        .HasColumnType("varchar(1024) CHARACTER SET utf8mb4")
                        .HasMaxLength(1024);

                    b.Property<long>("CreateTime")
                        .HasColumnName("create_time")
                        .HasColumnType("bigint");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(512) CHARACTER SET utf8mb4")
                        .HasMaxLength(512);

                    b.Property<string>("Owner")
                        .HasColumnName("owner")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<long>("UpdateTime")
                        .HasColumnName("Update_time")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("Name");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("cinema");
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.CinemaMovie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("CinemaId")
                        .HasColumnName("cinema_id")
                        .HasColumnType("bigint");

                    b.Property<long>("CreateTime")
                        .HasColumnName("create_time")
                        .HasColumnType("bigint");

                    b.Property<double>("DiscountPrice")
                        .HasColumnName("discount_price")
                        .HasColumnType("double");

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("MovieId")
                        .HasColumnName("movie_id")
                        .HasColumnType("bigint");

                    b.Property<string>("Owner")
                        .HasColumnName("owner")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("double");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<long>("UpdateTime")
                        .HasColumnName("Update_time")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("CreateTime");

                    b.HasIndex("MovieId");

                    b.HasIndex("Price");

                    b.HasIndex("Status");

                    b.HasIndex("UpdateTime");

                    b.ToTable("cinema_movie");
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.Movie", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint");

                    b.Property<long>("CreateTime")
                        .HasColumnName("create_time")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasMaxLength(2048);

                    b.Property<string>("Modifier")
                        .HasColumnName("modifier")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(512) CHARACTER SET utf8mb4")
                        .HasMaxLength(512);

                    b.Property<string>("Owner")
                        .HasColumnName("owner")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Rating")
                        .HasColumnName("rating")
                        .HasColumnType("double");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("VARCHAR(32)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type")
                        .HasColumnType("VARCHAR(64)");

                    b.Property<long>("UpdateTime")
                        .HasColumnName("Update_time")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CreateTime");

                    b.HasIndex("Name");

                    b.HasIndex("Rating");

                    b.HasIndex("Status");

                    b.HasIndex("Type");

                    b.HasIndex("UpdateTime");

                    b.ToTable("movie");
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Enums.EntityStatus", b =>
                {
                    b.Property<string>("V")
                        .HasColumnName("v")
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("V");

                    b.ToTable("entity_status");

                    b.HasData(
                        new
                        {
                            V = "ACTIVE"
                        },
                        new
                        {
                            V = "PASSIVE"
                        },
                        new
                        {
                            V = "DELETED"
                        });
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Enums.MovieType", b =>
                {
                    b.Property<string>("V")
                        .HasColumnName("v")
                        .HasColumnType("VARCHAR(64)");

                    b.HasKey("V");

                    b.ToTable("movie_type");

                    b.HasData(
                        new
                        {
                            V = "ACTION"
                        },
                        new
                        {
                            V = "DRAMA"
                        },
                        new
                        {
                            V = "COMEDY"
                        },
                        new
                        {
                            V = "HORROR"
                        },
                        new
                        {
                            V = "THRILLER"
                        },
                        new
                        {
                            V = "SCIENCE_FICTION"
                        },
                        new
                        {
                            V = "ADVENTURE"
                        },
                        new
                        {
                            V = "FASTASTIC"
                        },
                        new
                        {
                            V = "DETECTIVE"
                        });
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.Cinema", b =>
                {
                    b.HasOne("MoviesInTheaters.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.CinemaMovie", b =>
                {
                    b.HasOne("MoviesInTheaters.Data.Entities.Cinema", "Cinema")
                        .WithMany()
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoviesInTheaters.Data.Entities.Movie", "Movie")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoviesInTheaters.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MoviesInTheaters.Data.Entities.Movie", b =>
                {
                    b.HasOne("MoviesInTheaters.Data.Enums.EntityStatus", null)
                        .WithMany()
                        .HasForeignKey("Status")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("MoviesInTheaters.Data.Enums.MovieType", null)
                        .WithMany()
                        .HasForeignKey("Type")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
