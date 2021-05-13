using MoviesInTheaters.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.DTO
{
    public class CinemaDTO
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public EntityStatus.Values Status { get; set; }
        public long CreateTime { get; set; }
        public long UpdateTime { get; set; }

        public string Owner { get; set; }
        public string Modifier { get; set; }
    }
}
