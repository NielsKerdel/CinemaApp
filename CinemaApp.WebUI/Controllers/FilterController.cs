using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using CinemaApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class FilterController : Controller
    {
        IMovieRepository movieRepo;
        private IKijkwijzerRepository kijkwijzerRepo;
        private IScheduleRepository scheduleRepo;
        IFormatProvider provider;


        public FilterController(IMovieRepository movieRepoParam, IKijkwijzerRepository kijkwijzerRepoParam, IScheduleRepository scheduleRepoParam)
        {
            movieRepo = movieRepoParam;
            kijkwijzerRepo = kijkwijzerRepoParam;
            scheduleRepo = scheduleRepoParam;
            provider = new CultureInfo("nl-NL");
        }

        [HttpGet]
        public ViewResult FilteredMovieOverview(FilterResultViewModel model)
        {

            model.Kijkwijzer = kijkwijzerRepo.Kijkwijzers.ToList();
            model.Schedules = scheduleRepo.Schedules.ToList();
            model.Movies = movieRepo.Movies;

            MovieSummaryViewModel summaryModel = new MovieSummaryViewModel();
            if (model.selectedMovie != null
                || model.selectedDate != null
                || model.selectedTime != null)
            {
                // Movie was selected
                if (model.selectedMovie != "null")
                {
                    model.MovieList = movieRepo.Movies.Where(x => x.Name.Equals(model.selectedMovie));
                    return View(model);
                }
                // Date was selected
                if (model.selectedDate != null)
                {

                    model.MovieList = from s in scheduleRepo.Schedules.Where(s => s.Date >= model.selectedDate.Value)
                                      where movieRepo.Movies.FirstOrDefault(m => m.Id == s.Id) != null
                                      select s.movie;

                    return View(model);
                }
                // Time was selected
                if (model.selectedTime != null)
                {
                    model.MovieList = from s in scheduleRepo.Schedules.Where(s => s.Date.TimeOfDay >= model.selectedTime.Value.TimeOfDay)
                                      where movieRepo.Movies.FirstOrDefault(m => m.Id == s.Id) != null
                                      select s.movie;

                    return View(model);
                }
                //// Movie && Date were selected
                //else if (model.selectedMovie != "null" && model.selectedDate != null)
                //{

                //}
                //// Movie && Time were selected
                //else if (model.selectedMovie != "null" && model.selectedTime != null)
                //{

                //}
                //// Time && Date were selected
                //else if (model.selectedTime != null && model.selectedDate != null)
                //{

                //}
                //// Movie && Date && Time were selected
                //else if (model.selectedMovie != "null" && model.selectedDate != null && model.selectedTime != null)
                //{

                //}
            }

            model.MovieList = movieRepo.Movies;

            return View(model);
        }


        [HttpPost]
        public ActionResult FilteredMovieOverview()
        {

            FilterResultViewModel filterResultViewModel = new FilterResultViewModel();
            filterResultViewModel.selectedMovie = Request.Form["movieSelect"];
            string dateInput = Request.Form["date"];
            if (dateInput.Equals("") == false)
            {
                filterResultViewModel.selectedDate = DateTime.ParseExact(dateInput, "yyyy/MM/dd", provider);
            }

            string timeInput = Request.Form["time"];

            if (timeInput.Equals("") == false)
            {
                filterResultViewModel.selectedTime = DateTime.ParseExact(timeInput, "HH:mm", provider);
            }
            return RedirectToAction("FilteredMovieOverview", "Filter", filterResultViewModel);
        }


    }
}