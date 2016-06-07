using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ViewResult contact()
        {
            return View("Contact");
        }
    }
}