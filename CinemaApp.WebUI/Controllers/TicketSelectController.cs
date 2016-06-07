using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using CinemaApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class TicketSelectController : Controller
    {
        private IScheduleRepository scheduleRepo;
        private IMovieRepository movieRepo;
        private int currentMovieID;

        public TicketSelectController(IScheduleRepository scheduleRepoParam, IMovieRepository movieRepoParam)
        {
            scheduleRepo = scheduleRepoParam;
            movieRepo = movieRepoParam;
        }

        public ViewResult TicketSelect(int scheduleID)
        {
            SelectedMovieViewModel model = new SelectedMovieViewModel();
            model.schedule = scheduleRepo.Schedules.FirstOrDefault(x => x.Id == scheduleID);
            currentMovieID = model.schedule.movie.Id;
            model.movie = movieRepo.Movies.FirstOrDefault(x => x.Id == currentMovieID);


            return View("TicketSelect", model);
        }
    }
}