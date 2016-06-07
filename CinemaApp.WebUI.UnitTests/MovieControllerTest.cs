using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaApp.WebUI.Controllers;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CinemaApp.WebUI.UnitTests
{
    [TestClass]
    public class MovieControllerTest
    {
        MovieController controller;

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
                new Schedule { Id = 1, AvailableSeats = 9, hall = hallTest, movie = movieTest }
            });

            // Arrange
            controller = new MovieController(mockMovie.Object, mockKijkwijzer.Object, mockSchedule.Object);
        }

        [TestMethod()]
        public void MovieDetailsTest()
        {
            // Act
            var result = controller.MovieDetails(1) as ViewResult;

            // Assert
            Assert.AreEqual("Movie", result.ViewName);
        }

        [TestMethod()]
        public void MovieInfoOverviewTest()
        {
            // Act
            var result = controller.MovieInfoOverview(1) as ViewResult;

            // Assert
            Assert.AreEqual("MovieInfoOverview", result.ViewName);
        }
    }
}
