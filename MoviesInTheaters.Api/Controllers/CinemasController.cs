using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemasInTheaters.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Shared.DTO;

namespace MoviesInTheaters.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemasController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CinemaDTO>>> GetCinemaList()
        {
            var cinemaList = await _cinemaService.GetActiveCinemas();
            return _mapper.Map<IEnumerable<Cinema>,List<CinemaDTO>>(cinemaList);
        }

        [HttpGet]
        public async Task<ActionResult<CinemaDTO>> GetCinemaDetail(long id)
        {
            var cinema = await _cinemaService.GetCinemaById(id);
            return  _mapper.Map<Cinema,CinemaDTO>(cinema);
        }

        [HttpPost]
        public async Task<ActionResult<CinemaDTO>> CreateCinema([FromBody] CinemaCreateDTO cinemaDTO)
        {
            var cinemaToCreate = _mapper.Map<CinemaCreateDTO, Cinema>(cinemaDTO);
            var newCinema = await _cinemaService.CreateCinema(cinemaToCreate);
            return _mapper.Map<Cinema, CinemaDTO>(newCinema);
        }

        [HttpPut]
        public async Task<ActionResult<CinemaDTO>> UpdateCinema([FromBody] CinemaUpdateDTO cinemaDTO)
        {
            var cinema = _mapper.Map<CinemaUpdateDTO, Cinema>(cinemaDTO);
            var newCinema = await _cinemaService.UpdateCinema(cinema);
            return _mapper.Map<Cinema, CinemaDTO>(newCinema);
        }

        [HttpDelete]
        public async Task<ActionResult<CinemaDTO>> DeleteCinema(long id)
        {
            var cinema = await _cinemaService.GetCinemaById(id);            
            return _mapper.Map<Cinema, CinemaDTO>(await _cinemaService.DeleteCinema(cinema));
        }
    }
}
