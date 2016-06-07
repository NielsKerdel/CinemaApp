using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using CinemaApp.WebUI.Models;

namespace CinemaApp.WebUI.Controllers
{
    public class ChairController : Controller
    {
        private IChairRepository ChairRepo;
        private IScheduleRepository scheduleRepo;

        public ChairController(IChairRepository chairRepo, IScheduleRepository scheduleRepoParam)
        {
            ChairRepo = chairRepo;
            scheduleRepo = scheduleRepoParam;
        }
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ChairOverview(int scheduleID, int chairs, int totalTickets, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            ChairViewModel chairmodel = new ChairViewModel();
            chairmodel.chairs = ChairRepo.Chairs.Where(p => p.ScheduleID.hall.Id == scheduleID);
            ViewBag.Chairs = chairs;
            chairmodel.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
            chairmodel.chairQuantity = totalTickets;
            chairmodel.regularQuantity = totalRegular;
            chairmodel.childQuantity = totalChild;
            chairmodel.studentQuantity = totalStudent;
            chairmodel.seniorQuantity = totalSenior;
            chairmodel.popcornQuantity = totalPopcorn;
            chairmodel.ladiesQuantity = totalLadies;
            chairmodel.totalPrice = totalPrice;

            return View("ChairOverview", chairmodel);
        }
    }
}