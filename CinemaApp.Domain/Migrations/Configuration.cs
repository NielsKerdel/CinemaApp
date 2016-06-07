namespace CinemaApp.Domain.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CinemaApp.Domain.Concrete.EFDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CinemaApp.Domain.Concrete.EFDbContext context)
        {
            var movies = new List<Movie> {
                new Movie
                {
                    Id = 1,
                    Name = "Deadpool",
                    Description = "Na een duister experiment genezen zijn verwondingen razendsnel en bedenkt hij het alter ego Deadpool. Gewapend met zijn nieuwe gave en een goed gevoel voor (zwarte) humor gaat Deadpool op zoek naar de man die zijn leven bijna verwoestte.",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer = "Tim Miller",
                    Stars = "Ryan Rinolds, Morena Baccarin",
                    Website = "http://www.deadpoolcore.com",
                    IMDB = "http://www.imdb.com/title/tt1431045/?ref=fnaltt1/",
                    Trailer = "http://www.imdb.com/video/imdb/vi567457049/imdb/embed?autoplay=false&width=490",
                    ImageData = "deadpool.png",
                    Kijkwijzer = "DJH",
                    ThumbnailData = "deadpool_thumb.png",
                    Type = "3D",
                    Duration = 108
                },

                new Movie
                {
                    Id = 2,
                    Name = "The Divergent Series: Allegiant",
                    Description = "In The Divergent Series: Allegiant wagen Tris (Shailene Woodley) en Four (Theo James) zich in de wereld buiten het hek. Zij worden echter al snel in hechtenis genomen door een mysterieuze organisatie, die bekend staat als 'The Bureau of Genetic Welfare'. ",
                    Language = "Engles",
                    Subtitle = "Nederlands",
                    Writer = "Robert Schwentke",
                    Stars = "Shailene Woodley, Zoë Kravitz, Naomi Watts",
                    Website = "http://www.thedivergentseries.movie/#insurgent/",
                    IMDB = "http://www.imdb.com/title/tt3410834/?ref=nvsr4",
                    Trailer = "http://www.imdb.com/video/imdb/vi3709973785/imdb/embed?autoplay=false&width=490",
                    ImageData = "the_divergent_series_allegiant.png",
                    Kijkwijzer = "CH",
                    ThumbnailData = "the_divergent_series_allegiant_thumb.png",
                    Type = null,
                    Duration = 114
                },

                new Movie
                {
                    Id = 3,
                    Name = "London Has Fallen",
                    Description = "Wanneer de Engelse premier onder verdachte omstandigheden dood wordt gevonden, gaan alle alarmbellen af. Zijn begrafenis blijkt de ideale plek om een aanslag te plegen en de wereld ligt plots in de handen van slechts drie personen: de president van de Verenigde Staten (Eckhart), zijn meest betrouwbare geheim agent (Butler) en een Engelse MI-6 agent (Charlotte Riley)… ",
                    Language = "Engels",
                    Subtitle = "Nederlands",
                    Writer = "Babak Najafi",
                    Stars = "Gerard Butler, Aaron Eckhart, Morgan Freeman",
                    Website = "http://www.londonhasfallen.com/",
                    IMDB = "http://www.imdb.com/title/tt3300542/?ref=nvsr1",
                    Trailer = "http://www.imdb.com/video/imdb/vi1266857241/imdb/embed?autoplay=false&width=480",
                    ImageData = "london_has_fallen.png",
                    Kijkwijzer = "DJH",
                    ThumbnailData = "londen_has_fallen_thumb.png",
                    Type = null,
                    Duration = 125
                }
            };
            movies.ForEach(s => context.Movies.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            

            var locations = new List<Location> {
                new Location
                {
                    ID = 1,
                    Name = "Avans Breda",
                    City = "Breda",
                    Address = "Lovensdijksstraat 61",
                    ZipCode = "2839JF",
                    Phone = "0102930293",
                    Mail = "Breda@info.avans.nl",
                    Website = "avans.nl/Locations/Breda"
                },

                new Location
                {
                    ID = 2,
                    Name = "Avans Rotterdam",
                    City = "Rotterdam",
                    Address = "Schouwburgplein 54",
                    ZipCode = "4803HE",
                    Phone = "0109302930",
                    Mail = "Rotterdam@info.avans.nl",
                    Website = "avans.nl/Locations/Rotterdam"
                },

                new Location
                {
                    ID = 3,
                    Name = "Avans Tilburg",
                    City = "Tilburg",
                    Address = "VanGaalWeg 83",
                    ZipCode = "2930JB",
                    Phone = "0103920392",
                    Mail = "Tilburg@info.avans.nl",
                    Website = "avans.nl/Locations/Tilburg"
                }
            };
            locations.ForEach(s => context.Locations.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var halls = new List<Hall> {
                new Hall
                {
                    Id = 1,
                    LocationFK = 1,
                    Name = "Zaal 1",
                    TotalSeats = 50,
                    WheelchairAccesibility = false,
                    TotalRows = 5
                },

                new Hall
                {
                    Id = 2,
                    LocationFK = 1,
                    Name = "Zaal 2",
                    TotalSeats = 100,
                    WheelchairAccesibility = true,
                    TotalRows = 10
                },

                new Hall
                {
                    Id = 3,
                    LocationFK = 1,
                    Name = "Zaal 3",
                    TotalSeats = 150,
                    WheelchairAccesibility = true,
                    TotalRows = 15
                },

            };
            halls.ForEach(s => context.Halls.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            var genres = new List<Genre> {
                new Genre
                {
                    ID = 1,
                    Name = "Actie"
                },

                new Genre
                {
                    ID = 2,
                    Name = "Avontuur"
                },

                new Genre
                {
                    ID = 3,
                    Name = "Drama"
                },

                new Genre
                {
                    ID = 4,
                    Name = "Fantasy"
                },

                new Genre
                {
                    ID = 5,
                    Name = "Gangster"
                },

                new Genre
                {
                    ID = 6,
                    Name = "Historisch"
                },

                new Genre
                {
                    ID = 7,
                    Name = "Horror"
                },

                new Genre
                {
                    ID = 8,
                    Name = "Komedie"
                },

                new Genre
                {
                    ID = 9,
                    Name = "Kostuum"
                },

                new Genre
                {
                    ID = 10,
                    Name = "Melodrama"
                },

                new Genre
                {
                    ID = 11,
                    Name = "Misdaad"
                },

                new Genre
                {
                    ID = 12,
                    Name = "Musical"
                },

                new Genre
                {
                    ID = 13,
                    Name = "Oorlog"
                },

                new Genre
                {
                    ID = 14,
                    Name = "Romantisch"
                },

                new Genre
                {
                    ID = 15,
                    Name = "ScienceFiction"
                }
            };
            genres.ForEach(s => context.Genres.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var schedules = new List<Schedule> {
                new Schedule
                {
                    Id = 1,
                    Date = DateTime.Parse("2016-03-17 15:30"),
                    movieFK = 1,
                    hallFK = 1,
                    AvailableSeats = 50
                },

                new Schedule
                {
                    Id = 2,
                    Date = DateTime.Parse("2016-03-17 18:00"),
                    movieFK = 2,
                    hallFK = 2,
                    AvailableSeats = 100
                },

                new Schedule
                {
                    Id = 3,
                    Date = DateTime.Parse("2016-03-17 19:00"),
                    movieFK = 3,
                    hallFK = 3,
                    AvailableSeats = 150
                },

                new Schedule
                {
                    Id = 1,
                    Date = DateTime.Parse("2016-03-18 15:30"),
                    movieFK = 1,
                    hallFK = 2,
                    AvailableSeats = 50
                },

                new Schedule
                {
                    Id = 5,
                    Date = DateTime.Parse("2016-03-18 15:30"),
                    movieFK = 2,
                    hallFK = 2,
                    AvailableSeats = 100
                },

                new Schedule
                {
                    Id = 6,
                    Date = DateTime.Parse("2016-3-18 17:00"),
                    movieFK = 3,
                    hallFK = 3,
                    AvailableSeats = 150
                },

                new Schedule
                {
                    Id = 7,
                    Date = DateTime.Parse("2016-3-19 9:00"),
                    movieFK = 1,
                    hallFK = 1,
                    AvailableSeats = 50
                },

                new Schedule
                {
                    Id = 8,
                    Date = DateTime.Parse("2016-3-19 17:00"),
                    movieFK = 2,
                    hallFK = 2,
                    AvailableSeats = 100
                },

                new Schedule
                {
                    Id = 9,
                    Date = DateTime.Parse("2016-3-19 21:00"),
                    movieFK = 3,
                    hallFK = 3,
                    AvailableSeats = 150
                },

                new Schedule
                {
                    Id = 10,
                    Date = DateTime.Parse("2016-3-20 9:00"),
                    movieFK = 1,
                    hallFK = 1,
                    AvailableSeats = 50
                },

                new Schedule
                {
                    Id = 11,
                    Date = DateTime.Parse("2016-3-21 17:00"),
                    movieFK = 2,
                    hallFK = 2,
                    AvailableSeats = 100
                },

                new Schedule
                {
                    Id = 12,
                    Date = DateTime.Parse("2016-3-22 21:00"),
                    movieFK = 3,
                    hallFK = 3,
                    AvailableSeats = 150
                }
            };
            schedules.ForEach(s => context.Schedules.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();


            var rows = new List<Row> {
                new Row
                {
                    ID = 1,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 2,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 3,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 4,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 5,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 6,
                    HallFK = 1,
                    TotalSeats = 10
                },

                 new Row
                {
                    ID = 7,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 8,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 9,
                    HallFK = 1,
                    TotalSeats = 10
                },

                new Row
                {
                    ID = 10,
                    HallFK = 1,
                    TotalSeats = 10
                }
            };
            rows.ForEach(s => context.Rows.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var seats = new List<Seat>() {
                new Seat { ID = 1, SeatID = 11, RowFK = 1, HallFK = 1 },
                new Seat { ID = 2, SeatID = 12, RowFK = 1, HallFK = 1 },
                new Seat { ID = 3, SeatID = 13, RowFK = 1, HallFK = 1 },
                new Seat { ID = 4, SeatID = 14, RowFK = 1, HallFK = 1 },
                new Seat { ID = 5, SeatID = 15, RowFK = 1, HallFK = 1 },
                new Seat { ID = 6, SeatID = 16, RowFK = 1, HallFK = 1 },
                new Seat { ID = 7, SeatID = 17, RowFK = 1, HallFK = 1 },
                new Seat { ID = 8, SeatID = 18, RowFK = 1, HallFK = 1 },
                new Seat { ID = 9, SeatID = 19, RowFK = 1, HallFK = 1 },
                new Seat { ID = 10, SeatID = 20, RowFK = 1, HallFK = 1 },
                new Seat { ID = 11, SeatID = 21, RowFK = 1, HallFK = 1 },
                new Seat { ID = 12, SeatID = 22, RowFK = 1, HallFK = 1 },
                new Seat { ID = 13, SeatID = 23, RowFK = 1, HallFK = 1 },
                new Seat { ID = 14, SeatID = 24, RowFK = 1, HallFK = 1 },
                new Seat { ID = 15, SeatID = 25, RowFK = 1, HallFK = 1 },
                new Seat { ID = 16, SeatID = 26, RowFK = 1, HallFK = 1 },
                new Seat { ID = 17, SeatID = 27, RowFK = 1, HallFK = 1 },
                new Seat { ID = 18, SeatID = 28, RowFK = 1, HallFK = 1 },
                new Seat { ID = 19, SeatID = 29, RowFK = 1, HallFK = 1 },
                new Seat { ID = 20, SeatID = 30, RowFK = 1, HallFK = 1 },
                new Seat { ID = 21, SeatID = 11, RowFK = 2, HallFK = 1 },
                new Seat { ID = 22, SeatID = 12, RowFK = 2, HallFK = 1 },
                new Seat { ID = 23, SeatID = 13, RowFK = 2, HallFK = 1 },
                new Seat { ID = 24, SeatID = 14, RowFK = 2, HallFK = 1 },
                new Seat { ID = 25, SeatID = 15, RowFK = 2, HallFK = 1 },
                new Seat { ID = 26, SeatID = 16, RowFK = 2, HallFK = 1 },
                new Seat { ID = 27, SeatID = 17, RowFK = 2, HallFK = 1 },
                new Seat { ID = 28, SeatID = 18, RowFK = 2, HallFK = 1 },
                new Seat { ID = 29, SeatID = 19, RowFK = 2, HallFK = 1 },
                new Seat { ID = 30, SeatID = 20, RowFK = 2, HallFK = 1 },
                new Seat { ID = 31, SeatID = 21, RowFK = 2, HallFK = 1 },
                new Seat { ID = 32, SeatID = 22, RowFK = 2, HallFK = 1 },
                new Seat { ID = 33, SeatID = 23, RowFK = 2, HallFK = 1 },
                new Seat { ID = 34, SeatID = 24, RowFK = 2, HallFK = 1 },
                new Seat { ID = 35, SeatID = 25, RowFK = 2, HallFK = 1 },
                new Seat { ID = 36, SeatID = 26, RowFK = 2, HallFK = 1 },
                new Seat { ID = 37, SeatID = 27, RowFK = 2, HallFK = 1 },
                new Seat { ID = 38, SeatID = 28, RowFK = 2, HallFK = 1 },
                new Seat { ID = 39, SeatID = 29, RowFK = 2, HallFK = 1 },
                new Seat { ID = 40, SeatID = 30, RowFK = 2, HallFK = 1 },
                new Seat { ID = 41, SeatID = 11, RowFK = 3, HallFK = 1 },
                new Seat { ID = 42, SeatID = 12, RowFK = 3, HallFK = 1 },
                new Seat { ID = 43, SeatID = 13, RowFK = 3, HallFK = 1 },
                new Seat { ID = 44, SeatID = 14, RowFK = 3, HallFK = 1 },
                new Seat { ID = 45, SeatID = 15, RowFK = 3, HallFK = 1 },
                new Seat { ID = 46, SeatID = 16, RowFK = 3, HallFK = 1 },
                new Seat { ID = 47, SeatID = 17, RowFK = 3, HallFK = 1 },
                new Seat { ID = 48, SeatID = 18, RowFK = 3, HallFK = 1 },
                new Seat { ID = 49, SeatID = 19, RowFK = 3, HallFK = 1 },
                new Seat { ID = 50, SeatID = 20, RowFK = 3, HallFK = 1 },
                new Seat { ID = 51, SeatID = 21, RowFK = 3, HallFK = 1 },
                new Seat { ID = 52, SeatID = 22, RowFK = 3, HallFK = 1 },
                new Seat { ID = 53, SeatID = 23, RowFK = 3, HallFK = 1 },
                new Seat { ID = 54, SeatID = 24, RowFK = 3, HallFK = 1 },
                new Seat { ID = 55, SeatID = 25, RowFK = 3, HallFK = 1 },
                new Seat { ID = 56, SeatID = 26, RowFK = 3, HallFK = 1 },
                new Seat { ID = 57, SeatID = 27, RowFK = 3, HallFK = 1 },
                new Seat { ID = 58, SeatID = 28, RowFK = 3, HallFK = 1 },
                new Seat { ID = 59, SeatID = 29, RowFK = 3, HallFK = 1 },
                new Seat { ID = 60, SeatID = 30, RowFK = 3, HallFK = 1 },
                new Seat { ID = 61, SeatID = 11, RowFK = 4, HallFK = 1 },
                new Seat { ID = 62, SeatID = 12, RowFK = 4, HallFK = 1 },
                new Seat { ID = 63, SeatID = 13, RowFK = 4, HallFK = 1 },
                new Seat { ID = 64, SeatID = 14, RowFK = 4, HallFK = 1 },
                new Seat { ID = 65, SeatID = 15, RowFK = 4, HallFK = 1 },
                new Seat { ID = 66, SeatID = 16, RowFK = 4, HallFK = 1 },
                new Seat { ID = 67, SeatID = 17, RowFK = 4, HallFK = 1 },
                new Seat { ID = 68, SeatID = 18, RowFK = 4, HallFK = 1 },
                new Seat { ID = 69, SeatID = 19, RowFK = 4, HallFK = 1 },
                new Seat { ID = 70, SeatID = 20, RowFK = 4, HallFK = 1 },
                new Seat { ID = 71, SeatID = 21, RowFK = 4, HallFK = 1 },
                new Seat { ID = 72, SeatID = 22, RowFK = 4, HallFK = 1 },
                new Seat { ID = 73, SeatID = 23, RowFK = 4, HallFK = 1 },
                new Seat { ID = 74, SeatID = 24, RowFK = 4, HallFK = 1 },
                new Seat { ID = 75, SeatID = 25, RowFK = 4, HallFK = 1 },
                new Seat { ID = 76, SeatID = 26, RowFK = 4, HallFK = 1 },
                new Seat { ID = 77, SeatID = 27, RowFK = 4, HallFK = 1 },
                new Seat { ID = 78, SeatID = 28, RowFK = 4, HallFK = 1 },
                new Seat { ID = 79, SeatID = 29, RowFK = 4, HallFK = 1 },
                new Seat { ID = 80, SeatID = 30, RowFK = 4, HallFK = 1 },
                new Seat { ID = 81, SeatID = 11, RowFK = 5, HallFK = 1 },
                new Seat { ID = 82, SeatID = 12, RowFK = 5, HallFK = 1 },
                new Seat { ID = 83, SeatID = 13, RowFK = 5, HallFK = 1 },
                new Seat { ID = 84, SeatID = 14, RowFK = 5, HallFK = 1 },
                new Seat { ID = 85, SeatID = 15, RowFK = 5, HallFK = 1 },
                new Seat { ID = 86, SeatID = 16, RowFK = 5, HallFK = 1 },
                new Seat { ID = 87, SeatID = 17, RowFK = 5, HallFK = 1 },
                new Seat { ID = 88, SeatID = 18, RowFK = 5, HallFK = 1 },
                new Seat { ID = 89, SeatID = 19, RowFK = 5, HallFK = 1 },
                new Seat { ID = 90, SeatID = 20, RowFK = 5, HallFK = 1 },
                new Seat { ID = 91, SeatID = 21, RowFK = 5, HallFK = 1 },
                new Seat { ID = 92, SeatID = 22, RowFK = 5, HallFK = 1 },
                new Seat { ID = 93, SeatID = 23, RowFK = 5, HallFK = 1 },
                new Seat { ID = 94, SeatID = 24, RowFK = 5, HallFK = 1 },
                new Seat { ID = 95, SeatID = 25, RowFK = 5, HallFK = 1 },
                new Seat { ID = 96, SeatID = 26, RowFK = 5, HallFK = 1 },
                new Seat { ID = 97, SeatID = 27, RowFK = 5, HallFK = 1 },
                new Seat { ID = 98, SeatID = 28, RowFK = 5, HallFK = 1 },
                new Seat { ID = 99, SeatID = 29, RowFK = 5, HallFK = 1 },
                new Seat { ID = 100, SeatID = 30, RowFK = 5, HallFK = 1 }

            };


            seats.ForEach(s => context.Seats.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();

            var orders = new List<Order> {
                new Order
                {
                    ID = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1,
                    TicketFK = 1,
                    Paid = true
                },

                new Order
                {
                    ID = 1,
                    OrderCode = 23456,
                    ScheduleFK = 1,
                    TicketFK = 2,
                    Paid = true
                },

                new Order
                {
                    ID = 1,
                    OrderCode = 98765,
                    ScheduleFK = 1,
                    TicketFK = 3,
                    Paid = false
                }
            };
            orders.ForEach(s => context.Orders.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var rates = new List<Rate> {
                new Rate
                {
                    Name = "Studentenkorting",
                    Discount = 150,
                    Description = "Korting voor studerenden",
                },

                new Rate
                {
                    Name = "65+ korting",
                    Discount = 150,
                    Description = "Korting voor ouderen boven de 65",
                },

                new Rate
                {
                    Name = "Kinderkorting",
                    Discount = 150,
                    Description = "Korting voor kinderen onder de 6 jaar",
                }
            };
            rates.ForEach(s => context.Rates.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var tickets = new List<Ticket> {
                new Ticket
                {
                    ID = 1,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 1,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                },

                new Ticket
                {
                    ID = 2,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 2,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                },

                new Ticket
                {
                    ID = 3,
                    MovieFK = 1,
                    HallFK = 1,
                    RowFK = 1,
                    SeatFK = 3,
                    RateFK = 1,
                    OrderCode = 12345,
                    ScheduleFK = 1
                }
            };
            tickets.ForEach(s => context.Tickets.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();


            var chairs = new List<Chair>()
            {

                new Chair { ID =    1   , SeatFK =  1   , ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 2, SeatFK = 2, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 3, SeatFK = 3, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 4, SeatFK = 4, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 5, SeatFK = 5, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 6, SeatFK = 6, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 7, SeatFK = 7, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 8, SeatFK = 8, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 9, SeatFK = 9, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 10, SeatFK = 10, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 11, SeatFK = 11, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 12, SeatFK = 12, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 13, SeatFK = 13, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 14, SeatFK = 14, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 15, SeatFK = 15, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 16, SeatFK = 16, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 17, SeatFK = 17, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 18, SeatFK = 18, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 19, SeatFK = 19, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 20, SeatFK = 20, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 21, SeatFK = 21, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 22, SeatFK = 22, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 23, SeatFK = 23, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 24, SeatFK = 24, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 25, SeatFK = 25, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 26, SeatFK = 26, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 27, SeatFK = 27, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 28, SeatFK = 28, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 29, SeatFK = 29, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 30, SeatFK = 30, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 31, SeatFK = 31, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 32, SeatFK = 32, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 33, SeatFK = 33, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 34, SeatFK = 34, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 35, SeatFK = 35, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 36, SeatFK = 36, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 37, SeatFK = 37, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 38, SeatFK = 38, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 39, SeatFK = 39, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 40, SeatFK = 40, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 41, SeatFK = 41, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 42, SeatFK = 42, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 43, SeatFK = 43, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 44, SeatFK = 44, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 45, SeatFK = 45, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 46, SeatFK = 46, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 47, SeatFK = 47, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 48, SeatFK = 48, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 49, SeatFK = 49, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 50, SeatFK = 50, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 51, SeatFK = 51, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 52, SeatFK = 52, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 53, SeatFK = 53, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 54, SeatFK = 54, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 55, SeatFK = 55, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 56, SeatFK = 56, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 57, SeatFK = 57, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 58, SeatFK = 58, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 59, SeatFK = 59, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 60, SeatFK = 60, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 61, SeatFK = 61, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 62, SeatFK = 62, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 63, SeatFK = 63, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 64, SeatFK = 64, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 65, SeatFK = 65, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 66, SeatFK = 66, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 67, SeatFK = 67, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 68, SeatFK = 68, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 69, SeatFK = 69, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 70, SeatFK = 70, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 71, SeatFK = 71, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 72, SeatFK = 72, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 73, SeatFK = 73, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 74, SeatFK = 74, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 75, SeatFK = 75, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 76, SeatFK = 76, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 77, SeatFK = 77, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 78, SeatFK = 78, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 79, SeatFK = 79, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 80, SeatFK = 80, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 81, SeatFK = 81, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 82, SeatFK = 82, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 83, SeatFK = 83, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 84, SeatFK = 84, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 85, SeatFK = 85, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 86, SeatFK = 86, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 87, SeatFK = 87, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 88, SeatFK = 88, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 89, SeatFK = 89, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 90, SeatFK = 90, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 91, SeatFK = 91, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 92, SeatFK = 92, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 93, SeatFK = 93, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 94, SeatFK = 94, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 95, SeatFK = 95, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 96, SeatFK = 96, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 97, SeatFK = 97, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 98, SeatFK = 98, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 99, SeatFK = 99, ScheduleFK = 1, Reservation = 2 },
            new Chair { ID = 100, SeatFK = 100, ScheduleFK = 1, Reservation = 2 }
        };



        chairs.ForEach(s => context.Chairs.AddOrUpdate(p => p.ID, s));
            context.SaveChanges();
        }
    }
}
