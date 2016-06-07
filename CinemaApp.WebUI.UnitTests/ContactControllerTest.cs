using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CinemaApp.WebUI.Controllers;
using System.Web.Mvc;

namespace CinemaApp.WebUI.UnitTests
{
    [TestClass]
    public class ContactControllerTest
    {
        [TestMethod]
        public void Sends_back_contact_view_test()
        {
            // Arrange
            ContactController controller = new ContactController();

            // Act
            var result = controller.contact() as ViewResult;

            // Assert
            Assert.AreEqual("Contact", result.ViewName);

        }
    }
}
