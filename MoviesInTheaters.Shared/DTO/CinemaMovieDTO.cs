using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.DTO
{
    public class CinemaMovieDTO
    {

        public long Id { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public Cinema Cinema { get; set; }
        public long CinemaId { get; set; }
        public Movie Movie { get; set; }
        public long MovieId { get; set; }
        public long CreateTime { get; set; }
        public long UpdateTime { get; set; }

        public string Owner { get; set; }
        public string Modifier { get; set; }
        public EntityStatus.Values Status { get; set; }
    }
}
