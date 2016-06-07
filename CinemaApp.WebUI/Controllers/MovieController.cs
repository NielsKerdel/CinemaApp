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
    public class MovieController : Controller
    {
        private IMovieRepository movieRepo;
        private IKijkwijzerRepository kijkwijzerRepo;
        private IScheduleRepository scheduleRepo;

        public MovieController(IMovieRepository movieRepoParam, IKijkwijzerRepository kijkwijzerRepoParam, IScheduleRepository scheduleRepoParam)
        {
            movieRepo = movieRepoParam;
            kijkwijzerRepo = kijkwijzerRepoParam;
            scheduleRepo = scheduleRepoParam;
        }

        public ViewResult MovieDetails(int movieID = 0)
        {
            Movie movie = movieRepo.Movies.FirstOrDefault(m => m.Id == movieID);
            KijkwijzerViewModel kijkwijzerModel = new KijkwijzerViewModel();

            kijkwijzerModel.movie = movie;
            kijkwijzerModel.kijkwijzer = kijkwijzerRepo.Kijkwijzers.ToList();

            return View("Movie", kijkwijzerModel);
        }

        public ViewResult MovieInfoOverview(int scheduleID = 3)
        {
            ScheduleOverviewModel model = new ScheduleOverviewModel();

            model.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
           
            int movieID = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID).movie.Id;
            model.movie = movieRepo.Movies.FirstOrDefault(m => m.Id == movieID);

            return View("MovieInfoOverview", model);
        }

    }
}