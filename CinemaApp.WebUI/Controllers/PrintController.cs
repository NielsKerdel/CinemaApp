using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using CinemaApp.WebUI.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class PrintController : Controller
    {
        private ITicketRepository ticketRepo;
        private IScheduleRepository scheduleRepo;

        public PrintController(ITicketRepository ticketRepoParam, IScheduleRepository scheduleRepoParam)
        {
            ticketRepo = ticketRepoParam;
            scheduleRepo = scheduleRepoParam;
        }


        public ViewResult PrintTicket(int OrderCode)
        {
            Ticket ticketObject = ticketRepo.Tickets.FirstOrDefault(t => t.OrderCode == OrderCode);
            int scheduleID = ticketObject.ticketSchedule.Id;

            Schedule foundSchedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);

            IEnumerable<Ticket> foundTickets = ticketRepo.Tickets.Where(ti => ti.OrderCode == OrderCode);
            
            PrintTicketViewModel viewModel = new PrintTicketViewModel
            {
                Tickets = foundTickets.ToList(),

                schedule = foundSchedule,

            };

            return View("PrintTicket", viewModel);
        }

        [HttpPost]
        public ActionResult generatePDF(int OrderCode, bool isReservation = false)
        {
            if (isReservation)
            {
                return new ActionAsPdf("PrintTicket", new { orderCode = OrderCode }) { FileName = "Reservation-" + OrderCode + ".pdf" };
            } else { 
                return new ActionAsPdf("PrintTicket", new { orderCode = OrderCode}) { FileName = "Order-" + OrderCode + ".pdf" };
            }
        }


        public ViewResult confirmPrint()
        {
            return View("ConfirmPrint");
        }
    }
}