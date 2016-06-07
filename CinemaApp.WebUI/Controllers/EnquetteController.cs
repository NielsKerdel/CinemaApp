using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class EnquetteController : Controller
    {
        private IEnquetteRepository EnquetteRepo;

        public EnquetteController(IEnquetteRepository enquetteRepo)
        {
            EnquetteRepo = enquetteRepo;
        }

        [HttpGet]
        public ActionResult Enquette()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Enquette(Enquette enquette)
        {
            if (ModelState.IsValid)
            {
                EnquetteRepo.SaveEnquette(enquette);
                TempData["message"] = string.Format("{0} has been saved", enquette.Name);
                return RedirectToAction("Index", "Home");
            }
            else {
                // there is something wrong with the data values
                return View(enquette);
            }
        }
    }
}