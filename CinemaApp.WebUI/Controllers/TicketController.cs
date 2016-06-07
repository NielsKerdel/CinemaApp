using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using CinemaApp.WebUI.Models;

namespace CinemaApp.WebUI.Controllers
{
    public class TicketController : Controller
    {

        private IMovieRepository MovieRepo;
        private ITicketRepository TicketRepo;
        private IOrderRepository OrderRepo;
        private IScheduleRepository ScheduleRepo;
        private IRateRepository RateRepo;
        private int ticketID;

        public TicketController(IMovieRepository movieRepo, ITicketRepository ticketRepo, IOrderRepository orderRepo, IScheduleRepository scheduleRepo, IRateRepository rateRepo)
        {
            MovieRepo = movieRepo;
            TicketRepo = ticketRepo;
            OrderRepo = orderRepo;
            ScheduleRepo = scheduleRepo;
            RateRepo = rateRepo;
        }

        [HttpGet]
        public ViewResult OrderOverview()
        {
            return View("OrderOverview");
        }

        [HttpPost]
        // Return all tickets which match OrderID
        public ActionResult OrderOverview(Order order)
        {
            // OrderID exists
            if (order.OrderCode != 0)
            {
                var getOrder = OrderRepo.Orders.FirstOrDefault(or => or.OrderCode == order.OrderCode);

                if (getOrder != null)
                {
                    ticketID = getOrder.OrderCode; // Get the tickets                    

                    TicketViewModel model = new TicketViewModel();
                    model.movies = MovieRepo.Movies.ToArray();
                    model.tickets = TicketRepo.Tickets.Where(p => p.OrderCode == ticketID);

                    Ticket ticketNum = TicketRepo.Tickets.First(p => p.OrderCode == ticketID);
                    int scheduleId = ticketNum.ticketSchedule.Id;

                    model.schedules = ScheduleRepo.Schedules.Where(p => p.Id == scheduleId);

                    if (getOrder.Paid == true)
                    {
                        return View("TicketOverview", model);
                    }
                    else
                    {
                        return RedirectToAction("PinPayment", "Pin");
                    }
                }
                else
                {
                    ModelState.AddModelError("OrderOverview", "Geef a.u.b. een geldige code op");
                    return View();
                }
            }
            else
            {
                // Return nothing if no ordernumber has been given
                ModelState.AddModelError("OrderOverview", "Geef a.u.b. een geldige code op");
                return View("OrderOverview");
            }
        }

        [HttpPost]
        public ActionResult RateSelection(int id, decimal totalPrice, decimal totalDiscount, int scheduleID, int normalQuantity, int childQuantity, int studentQuantity, int seniorQuantity, int popcornQuantity, int ladiesQuantity, int dimensionalQuantity)
        {
            SelectedRatesViewModel RateModel = new SelectedRatesViewModel();
            RateModel.schedule = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == id);

            return View("RateSelection", RateModel);
        }


        [HttpPost]
        public ActionResult placeOrder(int orderCode, int id, int normalQuantity, int childQuantity, int studentQuantity, int seniorQuantity, int popcornQuantity, int ladiesQuantity, int dimensionalQuantity, decimal ticketsTotalPrice)
        {
            int ordernumber = orderCode;

            Ticket[] boughtTickets = createTicketList(id, normalQuantity, childQuantity, studentQuantity, seniorQuantity, popcornQuantity, ladiesQuantity, dimensionalQuantity);

            Schedule schedule = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == id);

            // TODO: Invoke save order method.
            //OrderRepo.saveOrder(ordernumber, schedule, boughtTickets, true);

            return RedirectToAction("PinPayment", "Pin", new { orderCode = ordernumber });
        }

        public ActionResult placeReservation(int reservationCode, int id, int normalQuantity, int childQuantity, int studentQuantity, int seniorQuantity, int popcornQuantity, int ladiesQuantity, int dimensionalQuantity, decimal ticketsTotalPrice)
        {
            int reservationNumber = reservationCode;

            Ticket[] boughtTickets = createTicketList(id, normalQuantity, childQuantity, studentQuantity, seniorQuantity, popcornQuantity, ladiesQuantity, dimensionalQuantity);

            Schedule schedule = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == id);

            // TODO: Invoke save order method.
            // OrderRepo.saveOrder(ordernumber, schedule, boughtTickets, false);

            return RedirectToAction("PinPayment", "Pin", new { orderCode = reservationNumber });
        }

        public int generateRandomOrderNr()
        {
            Random random = new Random();
            int randomNumber = random.Next(100000, 999999);

            bool recheck;
            do
            {
                if (OrderRepo.Orders.Any(x => x.OrderCode == randomNumber))
                {
                    randomNumber = random.Next(100000, 999999);

                    recheck = true;
                } else
                {
                    recheck = false;
                }
            } while (recheck);

            return randomNumber;

        }

        public Ticket[] createTicketList(int scheduleID, int normalQuantity, int childQuantity = 0, int studentQuantity = 0, int seniorQuantity = 0, int popcornQuantity = 0, int ladiesQuantity = 0, int dimensionalQuantity = 0)
        {
            // Create the list
            List<Ticket> ticketsBought = new List<Ticket>();

            // find schedule to add to tickets
            Schedule schedule = ScheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);

            // Retrieve current list of rates
            Rate[] rates = RateRepo.Rates.ToArray();

            // Create list with tickets and set the array size
            if (normalQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "normaal");

                for (int i = 1; i == normalQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate= rate });
                }
            }

            if (childQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "kind");
                for (int i = 1; i == childQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }

            if (studentQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "student");
                for (int i = 1; i == studentQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }

            if (seniorQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "senior");
                for (int i = 1; i == seniorQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }

            if (popcornQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "popcorn");
                for (int i = 1; i == popcornQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }

            if (ladiesQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "ladies");
                for (int i = 1; i == ladiesQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }

            if (dimensionalQuantity > 0)
            {
                Rate rate = RateRepo.Rates.FirstOrDefault(x => x.Name == "dimensionaal");
                for (int i = 1; i == dimensionalQuantity; i = i - 1)
                {
                    ticketsBought.Add(new Ticket { ticketSchedule = schedule, ticketRate = rate });
                }
            }


            return ticketsBought.ToArray();

        }

    }
}