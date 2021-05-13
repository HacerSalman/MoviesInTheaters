using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MoviesInTheaters.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.DTO;

namespace MoviesInTheaters.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> GetMovieList()
        {
            var movieList = await _movieService.GetActiveMovies();
            return _mapper.Map<IEnumerable<Movie>, List<MovieDTO>>(movieList);
        }

        [HttpGet]
        public async Task<ActionResult<MovieDTO>> GetMovieDetail(long id)
        {
            var movie = await _movieService.GetMovieById(id);
            return _mapper.Map<Movie, MovieDTO>(movie);
        }

        [HttpPost]
        public async Task<ActionResult<MovieDTO>> CreateMovie([FromBody] MovieCreateDTO movieDTO)
        {
            var movieToCreate = _mapper.Map<MovieCreateDTO, Movie>(movieDTO);
            var newMovie = await _movieService.CreateMovie(movieToCreate);
            return _mapper.Map<Movie, MovieDTO>(newMovie);
        }

        [HttpPut]
        public async Task<ActionResult<MovieDTO>> UpdateMovie([FromBody] MovieUpdateDTO movieDTO)
        {
            var movie = _mapper.Map<MovieUpdateDTO, Movie>(movieDTO);
            var newMovie = await _movieService.UpdateMovie(movie);
            return _mapper.Map<Movie, MovieDTO>(newMovie);
        }

        [HttpDelete]
        public async Task<ActionResult<MovieDTO>> DeleteMovie(long id)
        {
            var movie = await _movieService.GetMovieById(id);
            return _mapper.Map<Movie, MovieDTO>(await _movieService.DeleteMovie(movie));
        }
    }
}
