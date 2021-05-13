using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.DTO
{
    public class CinemaUpdateDTO
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public EntityStatus.Values Status { get; set; }
    }
}
