using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.WebUI.Models
{
    public class PaymentViewModel
    {

        public Schedule schedule { get; set; }
        public String row { get; set; }
        public int[] chairs { get; set; }
        public int generatedCode { get; set; }
        public int totalTickets { get; set; }
        public int regularQuantity { get; set; }
        public int childQuantity { get; set; }
        public int studentQuantity { get; set; }
        public int seniorQuantity { get; set; }
        public int popcornQuantity { get; set; }
        public int ladiesQuantity { get; set; }
        public decimal totalPrice { get; set; }

    }
}