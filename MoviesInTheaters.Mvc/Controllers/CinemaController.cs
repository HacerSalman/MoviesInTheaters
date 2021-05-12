using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemasInTheaters.Shared.Services;
using Microsoft.AspNetCore.Mvc;
using MoviesInTheaters.Data.Entities;
using MoviesInTheaters.Data.Enums;
using MoviesInTheaters.Shared.Utils;

namespace MoviesInTheaters.Mvc.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            _cinemaService = cinemaService;

        }

        private void FillStandardViewData()
        {
            ViewData["EntityStatus"] = EnumExtensions.PrepareSelectTag<EntityStatus.Values>();
        }
        public async Task<IActionResult> Index()
        {
            var CinemaList = await _cinemaService.GetAllCinemas();
            return View(CinemaList);
        }

        public async Task<ActionResult> Details(long id)
        {
            return View(await _cinemaService.GetCinemaById(id));
        }

        public ActionResult Create()
        {
            FillStandardViewData();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cinema Cinema)
        {
            if (ModelState.IsValid)
            {
                await _cinemaService.CreateCinema(Cinema);
                return RedirectToAction("Index");
            }

            return View(Cinema);
        }

        public async Task<ActionResult> Edit(long id)
        {
            FillStandardViewData();
            var Cinema = await _cinemaService.GetCinemaById(id);
            return View(Cinema);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cinema Cinema)
        {
            if (ModelState.IsValid)
            {
                 _cinemaService.UpdateCinema(Cinema);
                return RedirectToAction("Index");
            }
            return View(Cinema);
        }

        public async Task<ActionResult> Delete(long id)
        {
            var Cinema = await _cinemaService.GetCinemaById(id);
            return View(Cinema);
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
