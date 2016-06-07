using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaApp.WebUI.Controllers;
using System.Web.Mvc;
using CinemaApp.Domain.Abstract;
using Moq;
using CinemaApp.Domain.Entities;
using System.Collections.Generic;
using CinemaApp.WebUI.Models;

namespace CinemaApp.WebUI.UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        HomeController controller;

        [TestInitialize()]
        public void Initialize()
        {
            Mock<IMovieRepository> mockMovie = new Mock<IMovieRepository>();

            mockMovie.Setup(m => m.Movies).Returns(new List<Movie>
            {
                new Movie {
                    Id = 1,
                    Name = "Deadpool",
                    Description = "Na een duister experiment genezen zijn verwondingen razendsnel en bedenkt hij het alter ego Deadpool. Gewapend met zijn nieuwe gave en een goed gevoel voor (zwarte) humor gaat Deadpool op zoek naar de man die zijn leven bijna verwoestte.",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer = "Tim Miller",
                    Stars= "Ryan Rinolds, Morena Baccarin",
                    Website = "http://www.deadpoolcore.com",
                    IMDB = "http://www.imdb.com/title/tt1431045/?ref_=fn_al_tt_1/",
                    Trailer = "http://www.imdb.com/video/imdb/vi567457049/imdb/embed?autoplay=false&width=490",
                    Kijkwijzer = "DJH",
                    ImageData = "deadpool.png",
                    ThumbnailData ="deadpool_thumb.png" ,
                    Type = "3D"
                }
            });

            Mock<IKijkwijzerRepository> mockKijkwijzer = new Mock<IKijkwijzerRepository>();

            mockKijkwijzer.Setup(m => m.Kijkwijzers).Returns(new List<Kijkwijzer>
            {
                new Kijkwijzer { Name = "65+", Character = "Oude man", ImageData = null }
            });

            Hall hallTest = new Hall { Id = 3, CinemaID = null, Name = "Tom", TotalRows = 5, TotalSeats = 9, WheelchairAccesibility = false };
            Movie movieTest = new Movie
            {
                Id = 1,
                Name = "Deadpool",
                Description = "Na een duister experiment genezen zijn verwondingen razendsnel en bedenkt hij het alter ego Deadpool. Gewapend met zijn nieuwe gave en een goed gevoel voor (zwarte) humor gaat Deadpool op zoek naar de man die zijn leven bijna verwoestte.",
                Language = "Engels",
                Subtitle = "Nederlands",
                Writer = "Tim Miller",
                Stars = "Ryan Rinolds, Morena Baccarin",
                Website = "http://www.deadpoolcore.com",
                IMDB = "http://www.imdb.com/title/tt1431045/?ref_=fn_al_tt_1/",
                Trailer = "http://www.imdb.com/video/imdb/vi567457049/imdb/embed?autoplay=false&width=490",
                Kijkwijzer = "DJH",
                ImageData = "deadpool.png",
                ThumbnailData = "deadpool_thumb.png",
                Type = "3D"
            };

            Mock<IScheduleRepository> mockSchedule = new Mock<IScheduleRepository>();

            mockSchedule.Setup(m => m.Schedules).Returns(new List<Schedule>
            {
                new Schedule { Id = 1, Date = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd") + " 18:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 2, Date = DateTime.Parse(DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") + " 19:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 3, Date = DateTime.Parse(DateTime.Today.AddDays(2).ToString("yyyy-MM-dd") + " 20:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 4, Date = DateTime.Parse(DateTime.Today.AddDays(3).ToString("yyyy-MM-dd") + " 19:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 5, Date = DateTime.Parse(DateTime.Today.AddDays(4).ToString("yyyy-MM-dd") + " 20:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 6, Date = DateTime.Parse(DateTime.Today.AddDays(5).ToString("yyyy-MM-dd") + " 19:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest },
                new Schedule { Id = 7, Date = DateTime.Parse(DateTime.Today.AddDays(6).ToString("yyyy-MM-dd") + " 20:00"), AvailableSeats = 9, hall = hallTest, movie = movieTest }
            });

            // Arrange
            controller = new HomeController(mockMovie.Object, mockKijkwijzer.Object, mockSchedule.Object);


        }

        [TestMethod]
        public void IndexTest()
        {
            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void searchTest()
        {
            // Arrange - FilterResultViewModel
            FilterResultViewModel filteredModel = new FilterResultViewModel();
            filteredModel.selectedMovie = "Deadpool";
            filteredModel.selectedDate = DateTime.Parse(DateTime.Today.ToString("yyyy-MM-dd"));
            filteredModel.selectedTime = DateTime.Parse("18:00");

            // Act
            // var result = controller.Search(filteredModel) as ViewResult;

            // Assert
            // Assert.AreEqual("FilteredMovieOverview", result.ViewName);
        }

        [TestMethod]
        public void dayoverview_days_test()
        {
            // Act
            var plusZeroDaysResult = controller.DayOverview(0) as ViewResult;
            var plusOneDayResult = controller.DayOverview(1) as ViewResult;
            var plusTwoDaysResult = controller.DayOverview(2) as ViewResult;
            var plusThreeDaysResult = controller.DayOverview(3) as ViewResult;
            var plusFourDaysResult = controller.DayOverview(4) as ViewResult;
            var plusFiveDaysResult = controller.DayOverview(5) as ViewResult;
            var plusSixDaysResult = controller.DayOverview(6) as ViewResult;

            // Assert
            Assert.AreEqual("Index", plusZeroDaysResult.ViewName);
            Assert.AreEqual("Index", plusOneDayResult.ViewName);
            Assert.AreEqual("Index", plusTwoDaysResult.ViewName);
            Assert.AreEqual("Index", plusThreeDaysResult.ViewName);
            Assert.AreEqual("Index", plusFourDaysResult.ViewName);
            Assert.AreEqual("Index", plusFiveDaysResult.ViewName);
            Assert.AreEqual("Index", plusSixDaysResult.ViewName);

        }


    }
}
