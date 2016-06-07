using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaApp.Domain.Entities;
using System.Threading;
using System.Data.Entity;
using System.Globalization;
using CinemaApp.Domain.Abstract;
using CinemaApp.WebUI.Models;

namespace CinemaApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IMovieRepository movieRepo;
        private IKijkwijzerRepository kijkwijzerRepo;
        private IScheduleRepository scheduleRepo;
        private string currentDay;
        private CultureInfo culture;

        public HomeController(IMovieRepository movieRepoParam, IKijkwijzerRepository kijkwijzerRepoParam, IScheduleRepository scheduleRepoParam)
        {
            movieRepo = movieRepoParam;
            kijkwijzerRepo = kijkwijzerRepoParam;
            scheduleRepo = scheduleRepoParam;
            culture = new CultureInfo("nl-NL");
            currentDay = DateTime.Now.DayOfWeek.ToString();

        }

        public ViewResult Index()
        {
            DayOverviewModel newModel = new DayOverviewModel();

            newModel.schedules = scheduleRepo.Schedules.ToList();
            newModel.kijkwijzer = kijkwijzerRepo.Kijkwijzers.ToList();
            newModel.movies = movieRepo.Movies.ToList();
            newModel.amountAdded = 0;


            return View("Index", newModel);
        }


        public ViewResult DayOverview(int quantityDays)
        {
            DayOverviewModel dayModel = new DayOverviewModel();
            if (quantityDays == 0)
            {
                dayModel.schedules = scheduleRepo.Schedules.Where(x => x.Date == DateTime.Today).ToList();
            }
            else
            {
                dayModel.schedules = scheduleRepo.Schedules.Where(x => x.Date.ToString("yyyy-MM-dd") == DateTime.Today.AddDays(quantityDays).ToString("yyyy-MM-dd")).ToList();
            }

            dayModel.kijkwijzer = kijkwijzerRepo.Kijkwijzers.ToList();
            dayModel.movies = movieRepo.Movies.ToList();
            dayModel.amountAdded = quantityDays;

            return View("Index", dayModel);
        }


    }
}