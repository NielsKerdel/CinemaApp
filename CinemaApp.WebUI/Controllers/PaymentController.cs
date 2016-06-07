using CinemaApp.Domain.Abstract;
using CinemaApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CinemaApp.WebUI.Controllers
{
    public class PaymentController : Controller
    {

        private IOrderRepository OrderRepo;
        private IScheduleRepository scheduleRepo;
        

        public PaymentController(IOrderRepository orderRepo, IScheduleRepository scheduleRepoParam)
        {
            OrderRepo = orderRepo;
            scheduleRepo = scheduleRepoParam;
        }

        [HttpPost]
        public ViewResult selectionOverview(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            SelectionViewModel model = createSelectionViewModel(scheduleID, totalTickets, row, chairs, totalRegular, totalChild, totalStudent, totalSenior, totalPopcorn, totalLadies, totalPrice);

            return View("selectionOverview", model);
        }

        [HttpPost]
        public ViewResult PaymentChoice(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            PaymentViewModel model = createPaymentViewModel(false, scheduleID, totalTickets, row, chairs, totalRegular, totalChild, totalStudent, totalSenior, totalPopcorn, totalLadies, totalPrice);

            return View("PaymentChoice", model);
        }

        [HttpPost]
        public ViewResult IdealPayment(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            PaymentViewModel model = createPaymentViewModel(true, scheduleID, totalTickets, row, chairs, totalRegular, totalChild, totalStudent, totalSenior, totalPopcorn, totalLadies, totalPrice);

            return View("IdealPayment", model);
        }

        [HttpPost]
        public ViewResult CreditCardPayment(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            PaymentViewModel model = createPaymentViewModel(true, scheduleID, totalTickets, row, chairs, totalRegular, totalChild, totalStudent, totalSenior, totalPopcorn, totalLadies, totalPrice);

            return View("CreditCardPayment", model);
        }

        [HttpPost]
        public ViewResult Reservation(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            PaymentViewModel model = createPaymentViewModel(true, scheduleID, totalTickets, row, chairs, totalRegular, totalChild, totalStudent, totalSenior, totalPopcorn, totalLadies, totalPrice);
            // TODO: Invoke save to database method

            return View("Reservation", model);
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
                }
                else
                {
                    recheck = false;
                }
            } while (recheck);

            return randomNumber;

        }

        public PaymentViewModel createPaymentViewModel(bool savingOrder, int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            PaymentViewModel model = new PaymentViewModel();
            model.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
            model.totalTickets = totalTickets;
            model.row = row;
            model.regularQuantity = totalRegular;
            model.childQuantity = totalChild;
            model.studentQuantity = totalStudent;
            model.seniorQuantity = totalSenior;
            model.popcornQuantity = totalPopcorn;
            model.ladiesQuantity = totalLadies;
            model.totalPrice = totalPrice;

            if(savingOrder)
            {
                model.generatedCode = generateRandomOrderNr();
            }

            List<int> selectedChairs = new List<int>();
            int newChair = 0;
            string currentChair = "";
            string newChairString = chairs += " ";
            foreach (Char c in newChairString)
            {
                if (c.ToString() != " ")
                {
                    if (currentChair != "")
                    {
                        currentChair = currentChair += c.ToString();

                    }
                    else
                    {
                        currentChair = c.ToString();
                    }
                }
                else
                {
                    newChair = int.Parse(currentChair);
                    selectedChairs.Add(newChair);
                    newChair = 0;
                    currentChair = "";
                }

            }
            model.chairs = selectedChairs.ToArray();

            return model;
        }

        public SelectionViewModel createSelectionViewModel(int scheduleID, int totalTickets, string row, string chairs, int totalRegular, int totalChild, int totalStudent, int totalSenior, int totalPopcorn, int totalLadies, decimal totalPrice)
        {
            SelectionViewModel model = new SelectionViewModel();
            model.schedule = scheduleRepo.Schedules.FirstOrDefault(s => s.Id == scheduleID);
            model.totalTickets = totalTickets;
            model.row = row;
            model.regularQuantity = totalRegular;
            model.childQuantity = totalChild;
            model.studentQuantity = totalStudent;
            model.seniorQuantity = totalSenior;
            model.popcornQuantity = totalPopcorn;
            model.ladiesQuantity = totalLadies;
            model.totalPrice = totalPrice;

            List<int> selectedChairs = new List<int>();
            int newChair = 0;
            string currentChair = "";
            string removedWhiteSpace = chairs.Remove(0, 1);
            string newChairString = removedWhiteSpace += " ";
            foreach (Char c in newChairString)
            {
                if (c.ToString() != " ")
                {
                    if (currentChair != "")
                    {
                        currentChair = currentChair += c.ToString();

                    }
                    else
                    {
                        currentChair = c.ToString();
                    }
                }
                else
                {
                    newChair = int.Parse(currentChair);
                    selectedChairs.Add(newChair);
                    newChair = 0;
                    currentChair = "";
                }

            }
            model.chairs = selectedChairs.ToArray();

            return model;
        }
    }

}