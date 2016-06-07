using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaApp.WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Diagnostics.CodeAnalysis;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Abstract;
using Moq;

namespace CinemaApp.TouchApp.Controllers.Tests
{
    [TestClass()]
    public class ChairControllerTest
    {
        ChairController controller;

        [TestInitialize()]
        public void Initialize()
        {
            Hall hallTest = new Hall { Id = 3, CinemaID = null, Name = "Tom", TotalRows = 5, TotalSeats = 9, WheelchairAccesibility = false };
            Schedule scheduleTest = new Schedule { Id = 1, AvailableSeats = 9, hall = hallTest };

            Row rowTest1 = new Row { ID = 1, HallID = hallTest, TotalSeats = 9 };

            Seat seatTest1 = new Seat { ID = 11, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest2 = new Seat { ID = 12, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest3 = new Seat { ID = 13, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest4 = new Seat { ID = 14, HallID = hallTest, RowID = rowTest1 };
            Seat seatTest5 = new Seat { ID = 15, HallID = hallTest, RowID = rowTest1 };

            Mock<IChairRepository> mockChair = new Mock<IChairRepository>();
            mockChair.Setup(or => or.Chairs).Returns(new List<Chair>
            {
                new Chair { SeatID = seatTest1, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest2, ScheduleID = scheduleTest, Reservation = 1 },
                new Chair { SeatID = seatTest3, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest4, ScheduleID = scheduleTest, Reservation = 2 },
                new Chair { SeatID = seatTest5, ScheduleID = scheduleTest, Reservation = 2 }
            });

            Mock<IScheduleRepository> mockSchedule = new Mock<IScheduleRepository>();
            mockSchedule.Setup(s => s.Schedules).Returns(new List<Schedule>
            {
                new Schedule { Id = 1, AvailableSeats = 9, hall = hallTest }
            });


            // Arrange 
            controller = new ChairController(mockChair.Object, mockSchedule.Object);
        }

        [TestMethod()]
        public void IndexTest()
        {
            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod()]
        public void ReservationOverview_EnoughChairs_Test()
        {
            // Act
            var result = controller.ChairOverview(1, 3, 3, 2,0,0,0,0,0,27);

            // Assert
            Assert.AreEqual("ChairOverview", result.ViewName); // Change later to returned View
        }

        [TestMethod()]
        public void ReservationOverview_NotEnoughChairs_Test()
        {
            // Act
            var result = controller.ChairOverview(1, 5, 5, 5, 0, 0,0 ,0 ,0 ,45);

            // Assert
            Assert.AreEqual("ChairOverview", result.ViewName); // Change later to returned View
        }
    }
}