using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CinemasInTheaters.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.DTO;
using MoviesInTheaters.Shared.Utils;

namespace MoviesInTheaters.Mvc.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;
        private readonly IMapper _mapper;

        public CinemaController(ICinemaService cinemaService, IMapper mapper)
        {
            _cinemaService = cinemaService;
            _mapper = mapper;

        }

        private void FillStandardViewData()
        {
            ViewData["EntityStatus"] = EnumExtensions.PrepareSelectTag<EntityStatus.Values>();
        }
        public async Task<IActionResult> Index()
        {
            var cinemaList = await _cinemaService.GetAllCinemas();
            var cinemaDTOList = _mapper.Map<IEnumerable<Cinema>, IEnumerable<CinemaDTO>>(cinemaList);
            return View(cinemaDTOList);
        }

        public async Task<ActionResult> Details(long id)
        {
            var cinema = await _cinemaService.GetCinemaById(id);
            var cinemaDTO = _mapper.Map<Cinema, CinemaDTO>(cinema);
            return View(cinemaDTO);
        }

        public ActionResult Create()
        {
            var model = new CinemaCreateDTO();
            FillStandardViewData();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CinemaCreateDTO cinemaDTO)
        {
            if (ModelState.IsValid)
            {
                var cinema = _mapper.Map<CinemaCreateDTO, Cinema>(cinemaDTO);
                await _cinemaService.CreateCinema(cinema);
                return RedirectToAction("Index");
            }

            return View(cinemaDTO);
        }

        public async Task<ActionResult> Edit(long id)
        {
            FillStandardViewData();
            var cinema = await _cinemaService.GetCinemaById(id);
            var cinemaDTO = _mapper.Map<Cinema, CinemaUpdateDTO>(cinema);
            return View(cinemaDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CinemaUpdateDTO cinemaDTO)
        {
            if (ModelState.IsValid)
            {
                var cinema = _mapper.Map<CinemaUpdateDTO, Cinema>(cinemaDTO);
                await _cinemaService.UpdateCinema(cinema);
                return RedirectToAction("Index");
            }
            return View(cinemaDTO);
        }

        public async Task<ActionResult> Delete(long id)
        {
            var cinema = await _cinemaService.GetCinemaById(id);
            var cinemaDTO = _mapper.Map<Cinema, CinemaUpdateDTO>(cinema);
            return View(cinemaDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            var cinema = await _cinemaService.GetCinemaById(id);
            await _cinemaService.DeleteCinema(cinema);
            return RedirectToAction("Index");
        }

    }
}
