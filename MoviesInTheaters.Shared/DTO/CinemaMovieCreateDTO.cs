using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.DTO
{
    public class CinemaMovieCreateDTO
    {
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public long CinemaId { get; set; }
        public long MovieId { get; set; }
        public EntityStatus.Values Status { get; set; }
    }
}
