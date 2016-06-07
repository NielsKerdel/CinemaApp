using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Moq;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Abstract;
using CinemaApp.WebUI.Controllers;
using System.Web.Mvc;

namespace CinemaApp.WebUI.UnitTests
{
    [TestClass]
    public class TicketControllerTest
    {
        [TestMethod]
        public void OrderoverviewWithAndWithoutParameterTest()
        {
            // Arrange - setup empty mocks for controller
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });

            Order order = new Order { OrderCode = 12345 };

            // arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // act
            var result = ticketController.OrderOverview() as ViewResult;
            var result2 = ticketController.OrderOverview(order) as ActionResult;

            // Assert
            Assert.AreEqual("OrderOverview", result.ViewName);
            Assert.IsInstanceOfType(result2, typeof(ActionResult));

        }


        [TestMethod]
        public void RateSelectionTest()
        {
            // Arrange - setup empty mocks for controller
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });


            // arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            var result = ticketController.RateSelection(3, 22.00m, 2.20m, 3, 0, 0, 1, 0, 0, 0, 0) as ViewResult;

            Assert.AreEqual("RateSelection", result.ViewName);

        }



        [TestMethod]
        public void Generate_OrderNumber_Test()
        {
            // Arrange - setup empty mocks for controller
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });


            // arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            int result = ticketController.generateRandomOrderNr();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Ordernumber_has_six_characters_test()
        {

            // Arrange - setup empty mocks for controller
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });


            // arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            int result = ticketController.generateRandomOrderNr();
            int count = result.ToString().Length;

            // Assert
            Assert.AreEqual(6, count);

    }

        // WARNING: THIS TEST TAKES 30 OR MORE SECONDS
        [TestMethod]
        public void IsRandomNumberWithinRange()
        {
            // Arrange - setup empty mocks for controller
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });

            // Arrange
            int[] resultMin = new int[10];
            int[] resultMax = new int[10];
            int[] result1 = new int[899999];

            // arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            for (int n = 0; n < resultMax.Length; n++)
            {
                for (int i = 0; i < result1.Length; i++)
                {
                    result1[i] = ticketController.generateRandomOrderNr();
                }
                resultMax[n] = result1.Max();
                resultMin[n] = result1.Min();
            }
            // Assert
            Assert.IsTrue(resultMin.Min() >= 100000 && resultMax.Max() <= 999999);
        }



        [TestMethod]
        public void Can_place_reservation()
        {
            // Arrange set empty mocks
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();


            // Arrange set filled mock
            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            scheduleMock.Setup(s => s.Schedules).Returns(new Schedule[]
            {
                new Schedule {Id = 1 }
            });

            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();
            rateMock.Setup(r => r.Rates).Returns(new Rate[] {
                new Rate {ID = 1, Name = "normaal", Description = "regular ticket", Discount = 1 },
                new Rate {ID = 2, Name = "kind", Description = "Child visitors until the age of 12", Discount = 1 },
                new Rate {ID = 3, Name = "student", Description = "Student visitors", Discount = 1 },
                new Rate {ID = 4, Name = "senior", Description = "65+ visitors", Discount = 1 },
                new Rate {ID = 5, Name = "popcorn", Description = "Enjoy extra medium coke and popcorn", Discount = 1 },
                new Rate {ID = 6, Name = "ladies", Description = "Thursday ladies night", Discount = 1 },
                new Rate {ID = 7, Name = "dimensionaal", Description = "Three-dimensional movie", Discount = 1 },
            });

            // Arrange - set ticket quantities
            int scheduleID = 1;
            int normalQuantity = 1;
            int childQuantity = 2;
            int studentQuantity = 3;
            int seniorQuantity = 4;
            int popcornQuantity = 5;
            int ladiesQuantity = 6;
            int dimensionalQuantity = 7;
            decimal ticketsTotalPrice = 50.50m;

            // Arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            int reservationCode = ticketController.generateRandomOrderNr();
            var result = ticketController.placeReservation(reservationCode, scheduleID, normalQuantity, childQuantity, studentQuantity, seniorQuantity, popcornQuantity, ladiesQuantity, dimensionalQuantity, ticketsTotalPrice) as ActionResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "PinPayment");


        }

        [TestMethod]
        public void Can_place_order()
        {
            // Arrange set empty mocks
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();

            // Arrange set filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode =  123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });

            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            scheduleMock.Setup(s => s.Schedules).Returns(new Schedule[]
            {
                new Schedule {Id = 1 }
            });

            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();
            rateMock.Setup(r => r.Rates).Returns(new Rate[] {
                new Rate {ID = 1, Name = "normaal", Description = "regular ticket", Discount = 1 },
                new Rate {ID = 2, Name = "kind", Description = "Child visitors until the age of 12", Discount = 1 },
                new Rate {ID = 3, Name = "student", Description = "Student visitors", Discount = 1 },
                new Rate {ID = 4, Name = "senior", Description = "65+ visitors", Discount = 1 },
                new Rate {ID = 5, Name = "popcorn", Description = "Enjoy extra medium coke and popcorn", Discount = 1 },
                new Rate {ID = 6, Name = "ladies", Description = "Thursday ladies night", Discount = 1 },
                new Rate {ID = 7, Name = "dimensionaal", Description = "Three-dimensional movie", Discount = 1 },
            });

            // Arrange - set ticket quantities
            int scheduleID = 1;
            int normalQuantity = 1;
            int childQuantity = 2;
            int studentQuantity = 3;
            int seniorQuantity = 4;
            int popcornQuantity = 5;
            int ladiesQuantity = 6;
            int dimensionalQuantity = 7;
            decimal ticketsTotalPrice = 50.50m;


            // Arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act
            var result = ticketController.placeOrder(123456, scheduleID, normalQuantity, childQuantity, studentQuantity, seniorQuantity, popcornQuantity, ladiesQuantity, dimensionalQuantity, ticketsTotalPrice) as ActionResult;

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "PinPayment");
        }


        [TestMethod]
        public void Can_create_ticket_list()
        {
            // Arrange set empty mocks
            Mock<IMovieRepository> movieMock = new Mock<IMovieRepository>();
            Mock<ITicketRepository> ticketMock = new Mock<ITicketRepository>();
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();

            // Arrange set filled mock
            Mock<IRateRepository> rateMock = new Mock<IRateRepository>();
            rateMock.Setup(r => r.Rates).Returns(new Rate[] {
                new Rate {ID = 1, Name = "normaal", Description = "regular ticket", Discount = 1 },
                new Rate {ID = 2, Name = "kind", Description = "Child visitors until the age of 12", Discount = 1 },
                new Rate {ID = 3, Name = "student", Description = "Student visitors", Discount = 1 },
                new Rate {ID = 4, Name = "senior", Description = "65+ visitors", Discount = 1 },
                new Rate {ID = 5, Name = "popcorn", Description = "Enjoy extra medium coke and popcorn", Discount = 1 },
                new Rate {ID = 6, Name = "ladies", Description = "Thursday ladies night", Discount = 1 },
                new Rate {ID = 7, Name = "dimensionaal", Description = "Three-dimensional movie", Discount = 1 },
            });

            Mock<IScheduleRepository> scheduleMock = new Mock<IScheduleRepository>();
            scheduleMock.Setup(s => s.Schedules).Returns(new Schedule[]
            {
                new Schedule {Id = 1}
            });

            // Arrange - set quantities
            int givenScheduleID = 1;
            int givenNormalQuantity = 5;

            // Arrange - setup controller
            TicketController ticketController = new TicketController(movieMock.Object, ticketMock.Object, orderMock.Object, scheduleMock.Object, rateMock.Object);

            // Act - Create ticket array
            Ticket[] result = ticketController.createTicketList(givenScheduleID, givenNormalQuantity);

            // Assert
            Assert.IsNotNull(result);
            
        }



    }
}
