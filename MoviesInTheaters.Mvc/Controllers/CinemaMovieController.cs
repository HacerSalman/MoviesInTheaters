using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemasInTheaters.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.DTO;
using MoviesInTheaters.Shared.Services;
using MoviesInTheaters.Shared.Utils;

namespace MoviesInTheaters.Mvc.Controllers
{
    public class CinemaMovieController : Controller
    {
        private readonly ICinemaMovieService _cinemaMovieService;
        private readonly ICinemaService _cinemaService;
        private readonly IMovieService _movieService;
        private readonly IMapper _mapper;

        public CinemaMovieController(ICinemaMovieService cinemaMovieService, IMapper mapper, ICinemaService cinemaService, IMovieService movieService)
        {
            _cinemaMovieService = cinemaMovieService;
            _movieService = movieService;
            _cinemaService = cinemaService;
            _mapper = mapper;

        }

        private void FillStandardViewData(CinemaMovieUpdateDTO edit = null)
        {
            ViewData["EntityStatus"] = EnumExtensions.PrepareSelectTag<EntityStatus.Values>();

            var cinemas = _cinemaService.GetActiveCinemas().Result
                .Select(_ => new SelectListItem { Text = _.Name, Value = _.Id.ToString() })
                .OrderBy(_ => _.Text).ToList();
            var movies = _movieService.GetActiveMovies().Result
                 .Select(_ => new SelectListItem { Text = _.Name, Value = _.Id.ToString() })
                 .OrderBy(_ => _.Text).ToList();
            cinemas.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Choose Cinema"
            });
            movies.Insert(0, new SelectListItem
            {
                Value = "",
                Text = "Choose Movie"
            });
            if (edit != null)
            {
                if (cinemas.All(_ => _.Value != edit.CinemaId.ToString()))
                {
                    var cinema = _cinemaService.GetCinemaById(edit.CinemaId).Result;
                    cinemas.Insert(0, new SelectListItem { Text = cinema.Name, Value = cinema.Id.ToString() });
                }

                if (movies.All(_ => _.Value != edit.MovieId.ToString()))
                {
                    var movie = _movieService.GetMovieById(edit.MovieId).Result;
                    movies.Insert(0, new SelectListItem { Text = movie.Name, Value = movie.Id.ToString() });
                }
            }


            ViewBag.Movies = movies;
            ViewBag.Cinemas = cinemas;
        }
        public async Task<IActionResult> Index()
        {
            var cinemaMovieList = await _cinemaMovieService.GetCinemaMovieList();
            var cinemaMovieDTOList = _mapper.Map<IEnumerable<CinemaMovie>, IEnumerable<CinemaMovieDTO>>(cinemaMovieList);
            return View(cinemaMovieDTOList);
        }

        public async Task<ActionResult> Details(long id)
        {
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            var cinemaMovieDTO = _mapper.Map<CinemaMovie, CinemaMovieDTO>(cinemaMovie);
            return View(cinemaMovieDTO);
        }

        public ActionResult Create()
        {
            var model = new CinemaMovieCreateDTO();
            FillStandardViewData();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CinemaMovieCreateDTO cinemaMovieDTO)
        {
            if (ModelState.IsValid)
            {
                var cinemaMovie = _mapper.Map<CinemaMovieCreateDTO, CinemaMovie>(cinemaMovieDTO);
                await _cinemaMovieService.CreateCinemaMovie(cinemaMovie);
                return RedirectToAction("Index");
            }

            return View(cinemaMovieDTO);
        }

        public async Task<ActionResult> Edit(long id)
        {
            FillStandardViewData();
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            var cinemaMovieDTO = _mapper.Map<CinemaMovie, CinemaMovieUpdateDTO>(cinemaMovie);
            FillStandardViewData(cinemaMovieDTO);
            return View(cinemaMovieDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CinemaMovieUpdateDTO cinemaMovieDTO)
        {
            if (ModelState.IsValid)
            {
                var cinemaMovie = _mapper.Map<CinemaMovieUpdateDTO, CinemaMovie>(cinemaMovieDTO);
                await _cinemaMovieService.UpdateCinemaMovie(cinemaMovie);
                return RedirectToAction("Index");
            }
            FillStandardViewData(cinemaMovieDTO);
            return View(cinemaMovieDTO);
        }

        public async Task<ActionResult> Delete(long id)
        {
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            var cinemaMovieDTO = _mapper.Map<CinemaMovie, CinemaMovieDTO>(cinemaMovie);
            return View(cinemaMovieDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var cinemaMovie = await _cinemaMovieService.GetCinemaMovieById(id);
            await _cinemaMovieService.DeleteCinemaMovie(cinemaMovie);
            return RedirectToAction("Index");
        }
    }
}
