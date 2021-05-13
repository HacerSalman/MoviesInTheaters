using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesInTheaters.Shared.Models.Response
{
    public class PagedResponse<T> where T : class, new()
    {
        public List<T> Result { get; set; }
        public Paging Paging { get; set; }
    }
}
