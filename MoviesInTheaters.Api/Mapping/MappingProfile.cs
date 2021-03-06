using AutoMapper;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesInTheaters.Api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Cinema, CinemaDTO>().ReverseMap();
            CreateMap<Cinema, CinemaUpdateDTO>().ReverseMap();
            CreateMap<Cinema, CinemaCreateDTO>().ReverseMap();
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<Movie, MovieUpdateDTO>().ReverseMap();
            CreateMap<Movie, MovieCreateDTO>().ReverseMap();
            CreateMap<CinemaMovie, CinemaMovieDTO>().ReverseMap();
            CreateMap<CinemaMovie, CinemaMovieUpdateDTO>().ReverseMap();
            CreateMap<CinemaMovie, CinemaMovieCreateDTO>().ReverseMap();

        }
    }
}
