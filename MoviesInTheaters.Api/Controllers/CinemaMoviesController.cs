using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.DTO;
using MoviesInTheaters.Shared.Services;

namespace MoviesInTheaters.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CinemaMoviesController : ControllerBase
    {
        private readonly ICinemaMovieService _cinemaMovieService;
        private readonly IMapper _mapper;

        public CinemaMoviesController(ICinemaMovieService cinemaMovieService, IMapper mapper)
        {
            _cinemaMovieService = cinemaMovieService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<CinemaMovieDTO>>> GetCinemaMovieList()
        {
            var cinemaMovieList = await _cinemaMovieService.GetActiveCinemaMovieList();
            return _mapper.Map<IEnumerable<CinemaMovie>, List<CinemaMovieDTO>>(cinemaMovieList);
        }

        [HttpGet]
        public async Task<ActionResult<CinemaMovieDTO>> GetCinemaMovieDetail(long id)
        {
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            return _mapper.Map<CinemaMovie, CinemaMovieDTO>(cinemaMovie);
        }

        [HttpPost]
        public async Task<ActionResult<CinemaMovieDTO>> CreateCinemaMovie([FromBody] CinemaMovieCreateDTO cinemaMovieDTO)
        {
            var cinemaMovieToCreate = _mapper.Map<CinemaMovieCreateDTO, CinemaMovie>(cinemaMovieDTO);
            var newCinemaMovie = await _cinemaMovieService.CreateCinemaMovie(cinemaMovieToCreate);
            return _mapper.Map<CinemaMovie, CinemaMovieDTO>(newCinemaMovie);
        }

        [HttpPut]
        public async Task<ActionResult<CinemaMovieDTO>> UpdateCinemaMovie([FromBody] CinemaMovieUpdateDTO cinemaMovieDTO)
        {
            var cinemaMovie = _mapper.Map<CinemaMovieUpdateDTO, CinemaMovie>(cinemaMovieDTO);
            var newCinemaMovie = await _cinemaMovieService.UpdateCinemaMovie(cinemaMovie);
            return _mapper.Map<CinemaMovie, CinemaMovieDTO>(newCinemaMovie);
        }

        [HttpDelete]
        public async Task<ActionResult<CinemaMovieDTO>> DeleteCinemaMovie(long id)
        {
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            return _mapper.Map<CinemaMovie, CinemaMovieDTO>(await _cinemaMovieService.DeleteCinemaMovie(cinemaMovie));
        }
    }
}
