using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CinemaApp.Domain.Entities;
using CinemaApp.Domain.Abstract;
using CinemaApp.WebUI.Controllers;
using System.Web.Mvc;
using CinemaApp.WebUI.Models;
using System.Linq;
using System.Collections.Generic;

namespace CinemaApp.WebUI.UnitTests
{
    [TestClass]
    public class PaymentControllerTest
    {
        [TestMethod]
        public void selectionOverviewTest()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            var result = target.selectionOverview(3, 1, "4", " 2 4", 1, 0, 0, 0, 0, 0, 11) as ViewResult;

            //Assert - check the result
            Assert.AreEqual("selectionOverview", result.ViewName);
        }

        [TestMethod]
        public void paymentChoiceTest()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            var result = target.PaymentChoice(3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as ViewResult;

            //Assert - check the result
            Assert.AreEqual("PaymentChoice", result.ViewName);
        }


        [TestMethod]
        public void ViewSelectionMethodCreditCardPayment()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            var result = target.CreditCardPayment(3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as ViewResult;

            //Assert - check the result
            Assert.AreEqual("CreditCardPayment", result.ViewName);
        }

        [TestMethod]
        public void ViewSelectionMethodIdealPayment()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            ViewResult result = target.IdealPayment(3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as ViewResult;

            //Assert - check the result
            Assert.AreEqual("IdealPayment", result.ViewName);
        }

        [TestMethod]
        public void reservationViewTest()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            ViewResult result = target.Reservation(3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as ViewResult;

            //Assert - check the result
            Assert.AreEqual("Reservation", result.ViewName);
        }

        [TestMethod]
        public void createViewModelsTest()
        {
            // Create mock object
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();
            mock2.Setup(s => s.Schedules).Returns(new List<Schedule> {
                new Schedule { Id = 3 }
            });

            // Arrange - create the controller
            PaymentController target = new PaymentController(mock.Object, mock2.Object);

            // Act - call the action method
            var result = target.createPaymentViewModel(true, 3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as PaymentViewModel;
            var result2 = target.createPaymentViewModel(false, 3, 1, "4", "2 4", 1, 0, 0, 0, 0, 0, 11) as PaymentViewModel;
            var result3 = target.createSelectionViewModel(3, 1, "4", " 2 4", 1, 0, 0, 0, 0, 0, 11) as SelectionViewModel;

            //Assert - check the result
            Assert.IsInstanceOfType(result, typeof(PaymentViewModel));
            Assert.IsInstanceOfType(result2, typeof(PaymentViewModel));
            Assert.IsInstanceOfType(result3, typeof(SelectionViewModel));

        }


        [TestMethod]
        public void Ordernumber_has_six_characters_test()
        {

            // Create mock object
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();

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


            // Arrange - create the controller
            PaymentController target = new PaymentController(orderMock.Object, mock2.Object);

            // Act
            int result = target.generateRandomOrderNr();
            int count = result.ToString().Length;

            // Assert
            Assert.AreEqual(6, count);

        }

        // WARNING: THIS TEST TAKES 30 OR MORE SECONDS
        [TestMethod]
        public void IsRandomNumberWithinRange()
        {
            // Create mock object
            Mock<IScheduleRepository> mock2 = new Mock<IScheduleRepository>();

            // Arrange - setup filled mock
            Mock<IOrderRepository> orderMock = new Mock<IOrderRepository>();
            orderMock.Setup(o => o.Orders).Returns(new Order[]
            {
                new Order {OrderCode = 123456},
                new Order {OrderCode = 123457 },
                new Order {OrderCode = 123458 },
                new Order {OrderCode = 123459 },
                new Order {OrderCode = 123450 },
            });

            // Arrange
            int[] resultMin = new int[10];
            int[] resultMax = new int[10];
            int[] result1 = new int[899999];

            // Arrange - create the controller
            PaymentController target = new PaymentController(orderMock.Object, mock2.Object);

            // Act
            for (int n = 0; n < resultMax.Length; n++)
            {
                for (int i = 0; i < result1.Length; i++)
                {
                    result1[i] = target.generateRandomOrderNr();
                }
                resultMax[n] = result1.Max();
                resultMin[n] = result1.Min();
            }
            // Assert
            Assert.IsTrue(resultMin.Min() >= 100000 && resultMax.Max() <= 999999);
        }


    }
}
