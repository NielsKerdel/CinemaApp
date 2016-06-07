using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Moq;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Concrete;

namespace CinemaApp.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IEnquetteRepository>().To<EFEnquetteRepository>();

            Mock<IMovieRepository> mock = new Mock<IMovieRepository>();

            mock.Setup(m => m.Movies).Returns(new List<Movie>
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
                },

                new Movie
                {
                    Id = 2,
                    Name = "The Divergent Series: Allegiant",
                    Description = "n The Divergent Series: Allegiant wagen Tris (Shailene Woodley) en Four (Theo James) zich in de wereld buiten het hek. Zij worden echter al snel in hechtenis genomen door een mysterieuze organisatie, die bekend staat als 'The Bureau of Genetic Welfare'. ",
                    Language = "Engles",
                    Subtitle = "Nederlands",
                    Writer = "Robert Schwentke",
                    Stars = "Shailene Woodley, Zoë Kravitz, Naomi Watts",
                    Website = "http://www.thedivergentseries.movie/#insurgent/",
                    IMDB = "http://www.imdb.com/title/tt3410834/?ref_=nv_sr_4",
                    Trailer ="http://www.imdb.com/video/imdb/vi3709973785/imdb/embed?autoplay=false&width=490",
                    Kijkwijzer ="CH",
                    ImageData = "the_divergent_series_allegiant.png",
                    ThumbnailData = "the_divergent_series_allegiant_thumb.png"
                },

                new Movie
                {
                    Id = 3,
                    Name = "London Has Fallen",
                    Description = "Wanneer de Engelse premier onder verdachte omstandigheden dood wordt gevonden, gaan alle alarmbellen af. Zijn begrafenis blijkt de ideale plek om een aanslag te plegen en de wereld ligt plots in de handen van slechts drie personen: de president van de Verenigde Staten (Eckhart), zijn meest betrouwbare geheim agent (Butler) en een Engelse MI-6 agent (Charlotte Riley)… ",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer ="Babak Najafi",
                    Stars = "Gerard Butler, Aaron Eckhart, Morgan Freeman",
                    Website ="http://www.londonhasfallen.com/",
                    IMDB ="http://www.imdb.com/title/tt3300542/?ref_=nv_sr_1",
                    Trailer ="http://www.imdb.com/video/imdb/vi1266857241/imdb/embed?autoplay=false&width=480",
                    Kijkwijzer = "DJH",
                    ImageData ="london_has_fallen.png",
                    ThumbnailData = "londen_has_fallen_thumb.png"
                }
            });

            kernel.Bind<IMovieRepository>().ToConstant(mock.Object);

            Mock<IKijkwijzerRepository> mock2 = new Mock<IKijkwijzerRepository>();

            mock2.Setup(k => k.Kijkwijzers).Returns(new List<Kijkwijzer>
            {
                new Kijkwijzer {Character = "A", ImageData = "AlleLeeftijden.png"},
                new Kijkwijzer {Character = "B", ImageData = "9jaar.png" },
                new Kijkwijzer {Character = "C", ImageData = "12jaar.png" },
                new Kijkwijzer {Character = "D", ImageData = "16jaar.png" },
                new Kijkwijzer {Character = "E", ImageData = "Angst.png" },
                new Kijkwijzer {Character = "F", ImageData = "Discriminatie.png" },
                new Kijkwijzer {Character = "G", ImageData = "Drugs.png" },
                new Kijkwijzer {Character = "H", ImageData = "Geweld.png" },
                new Kijkwijzer {Character = "I", ImageData = "Seks.png" },
                new Kijkwijzer {Character = "J", ImageData = "Taalgebruik.png" }
            });
            kernel.Bind<IKijkwijzerRepository>().ToConstant(mock2.Object);

            Mock<IHallRepository> mock3 = new Mock<IHallRepository>();
            mock3.Setup(h => h.Halls).Returns(new List<Hall>
            {
                new Hall {Id = 1, Name = "Zaal 1", WheelchairAccesibility = true },
                new Hall {Id = 2, Name = "Zaal 2", WheelchairAccesibility = true },
                new Hall {Id = 3, Name = "Zaal 3", WheelchairAccesibility = true },
                new Hall {Id = 4, Name = "Zaal 4", WheelchairAccesibility = true },
                new Hall {Id = 5, Name = "Zaal 5", WheelchairAccesibility = false},
                new Hall {Id = 6, Name = "Zaal 6", WheelchairAccesibility = false}
            });

            kernel.Bind<IHallRepository>().ToConstant(mock3.Object);




            Mock<IScheduleRepository> mock4 = new Mock<IScheduleRepository>();

            mock4.Setup(s => s.Schedules).Returns(new List<Schedule>
            {
                new Schedule {
                    Id = 1,
                    Date = DateTime.Parse("2016-03-13 15:30"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 1),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 1)
                },
                new Schedule {
                    Id = 2,
                    Date = DateTime.Parse("2016-03-13 18:00"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 2),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 2)
                },
                new Schedule {
                    Id = 3,
                    Date = DateTime.Parse("2016-03-14 19:00"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 1),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 3)
                },
                new Schedule {
                    Id = 4,
                    Date = DateTime.Parse("2016-03-13 15:30"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 2),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 3)
                },
                new Schedule {
                    Id = 5,
                    Date = DateTime.Parse("2016-03-13 15:30"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 3),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 1)
                },
                new Schedule {
                    Id = 6,
                    Date = DateTime.Parse("2016-3-14 17:00"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 3),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 6)
                }
            });

            kernel.Bind<IScheduleRepository>().ToConstant(mock4.Object);

            Mock<IOrderRepository> mock5 = new Mock<IOrderRepository>();
            kernel.Bind<IOrderRepository>().ToConstant(mock5.Object);

            Hall hallTest = new Hall { Id = 3, Name = "Zaal 3", WheelchairAccesibility = true };
            Schedule scheduleTest =
                new Schedule
                {
                    Id = 3,
                    Date = DateTime.Parse("2016-03-14 19:00"),
                    movie = mock.Object.Movies.FirstOrDefault(m => m.Id == 1),
                    hall = mock3.Object.Halls.FirstOrDefault(h => h.Id == 3)
                };

            Row rowTest1 = new Row { ID = 1, HallID = hallTest, TotalSeats = 9 };
            Row rowTest2 = new Row { ID = 2, HallID = hallTest, TotalSeats = 9 };
            Row rowTest3 = new Row { ID = 3, HallID = hallTest, TotalSeats = 9 };
            Row rowTest4 = new Row { ID = 4, HallID = hallTest, TotalSeats = 9 };
            Row rowTest5 = new Row { ID = 5, HallID = hallTest, TotalSeats = 9 };
            Seat seatTest1 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest2 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest3 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest4 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest5 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest6 = new Seat { ID = 16, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest7 = new Seat { ID = 17, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest8 = new Seat { ID = 18, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest9 = new Seat { ID = 19, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest10 = new Seat { ID = 2, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest11 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest12 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest13 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest14 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest15 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest16 = new Seat { ID = 16, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest17 = new Seat { ID = 17, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest18 = new Seat { ID = 18, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest19 = new Seat { ID = 19, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest20 = new Seat { ID = 2, HallID = hallTest, RowID = rowTest2 };
            Seat seatTest21 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest22 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest23 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest24 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest25 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest26 = new Seat { ID = 16, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest27 = new Seat { ID = 17, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest28 = new Seat { ID = 18, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest29 = new Seat { ID = 19, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest30 = new Seat { ID = 2, HallID = hallTest, RowID = rowTest3 };
            Seat seatTest31 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest32 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest33 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest34 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest35 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest36 = new Seat { ID = 16, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest37 = new Seat { ID = 17, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest38 = new Seat { ID = 18, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest39 = new Seat { ID = 19, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest40 = new Seat { ID = 2, HallID = hallTest, RowID = rowTest4 };
            Seat seatTest41 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest42 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest43 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest44 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest45 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest46 = new Seat { ID = 16, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest47 = new Seat { ID = 17, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest48 = new Seat { ID = 18, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest49 = new Seat { ID = 19, HallID = hallTest, RowID = rowTest5 };
            Seat seatTest50 = new Seat { ID = 2, HallID = hallTest, RowID = rowTest5 };

            Mock<IChairRepository> mockChair = new Mock<IChairRepository>();
            mockChair.Setup(or => or.Chairs).Returns(new List<Chair>
            {
                new Chair { SeatID = seatTest1, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest2, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest3, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest4, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest5, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest6, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest7, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest8, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest9, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest10, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest11, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest12, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest13, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest14, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest15, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest16, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest17, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest18, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest19, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest20, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest21, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest22, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest23, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest24, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest25, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest26, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest27, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest28, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest29, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest30, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest31, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest32, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest33, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest34, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest35, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest36, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest37, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest38, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest39, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest40, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest41, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest42, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest43, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest44, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest45, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest46, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest47, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest48, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest49, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest50, ScheduleID = scheduleTest, Reservation = 2 }
            });
            kernel.Bind<IChairRepository>().ToConstant(mockChair.Object);

        }
    }
}