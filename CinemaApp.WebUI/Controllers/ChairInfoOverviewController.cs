using CinemaApp.Domain.Abstract;
using CinemaApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class ChairOverviewController : Controller
    {
         private IChairRepository ChairRepo;
         private IMovieRepository MovieRepo;
         private IScheduleRepository ScheduleRepo;

        public ChairOverviewController(IChairRepository chairRepo, IMovieRepository movieRepo, IScheduleRepository scheduleRepo)
        {
            ChairRepo = chairRepo;
            MovieRepo = movieRepo;
            ScheduleRepo = scheduleRepo;

        }

        // GET: ChairOverview
        public ViewResult ChairInfoOverview(int scheduleID, int chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            ChairViewModel model = new ChairViewModel();
            model.schedule = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);

            model.chairs = ChairRepo.Chairs.Where(p => p.ScheduleID.hall.Id == scheduleID);

            int movieID = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID).movie.Id;
            model.movie = MovieRepo.Movies.FirstOrDefault(m => m.Id == movieID);

            model.chairQuantity = chairs;

            model.regularQuantity = totalRegular;
            model.childQuantity = totalChild;
            model.studentQuantity = totalStudent;
            model.seniorQuantity = totalSenior;
            model.popcornQuantity = totalPopcorn;
            model.ladiesQuantity = totalLadies;
            model.totalPrice = totalPrice;

            return View("ChairInfoOverview", model);
        }
    }
}