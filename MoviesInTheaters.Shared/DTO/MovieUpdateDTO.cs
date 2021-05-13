using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.DTO
{
    public class MovieUpdateDTO
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public MovieType.Values Type { get; set; }
        public double Rating { get; set; }
        public string Name { get; set; }

        public MovieDurationType.Values DurationType { get; set; }

        public int Duration { get; set; }
        public EntityStatus.Values Status { get; set; }
    }
}
