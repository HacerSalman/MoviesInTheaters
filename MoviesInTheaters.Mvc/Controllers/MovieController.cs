using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.DTO;
using MoviesInTheaters.Shared.Services;
using MoviesInTheaters.Shared.Utils;

namespace MoviesInTheaters.Mvc.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;

        }

        private void FillStandardViewData()
        {
            ViewData["EntityStatus"] = EnumExtensions.PrepareSelectTag<EntityStatus.Values>();
            ViewData["MovieType"] = EnumExtensions.PrepareSelectTag<MovieType.Values>();
            ViewData["MovieDurationType"] = EnumExtensions.PrepareSelectTag<MovieDurationType.Values>();
        }
        public async Task<IActionResult> Index()
        {
            var movieList = await _movieService.GetAllMovies();
            var movieDTOList = _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDTO>>(movieList);
            return View(movieDTOList);
        }

        public async Task<ActionResult> Details(long id)
        {
            var movie = await _movieService.GetMovieById(id);
            var movieDTO = _mapper.Map<Movie, MovieDTO>(movie);
            return View(movieDTO);
        }

        public ActionResult Create()
        {
            var model = new MovieCreateDTO();
            FillStandardViewData();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieCreateDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                var movie = _mapper.Map<MovieCreateDTO, Movie>(movieDTO);
                await _movieService.CreateMovie(movie);
                return RedirectToAction("Index");
            }

            return View(movieDTO);
        }

        public async Task<ActionResult> Edit(long id)
        {
            FillStandardViewData();
            var movie = await _movieService.GetMovieById(id);
            var movieDTO = _mapper.Map<Movie, MovieUpdateDTO>(movie);
            return View(movieDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MovieUpdateDTO movieDTO)
        {
            if (ModelState.IsValid)
            {
                var movie = _mapper.Map<MovieUpdateDTO, Movie>(movieDTO);
                await _movieService.UpdateMovie(movie);
                return RedirectToAction("Index");
            }
            return View(movieDTO);
        }

        public async Task<ActionResult> Delete(long id)
        {
            var movie = await _movieService.GetMovieById(id);
            var movieDTO = _mapper.Map<Movie, MovieDTO>(movie);
            return View(movieDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var movie = await _movieService.GetMovieById(id);
            await _movieService.DeleteMovie(movie);
            return RedirectToAction("Index");
        }
    }
}
