using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaApp.Domain.Entities;

namespace CinemaApp.WebUI.Models
{
    public class SelectedRatesViewModel
    {
        // Main data
        public int totalPrice { get; set; }
        public int totalDiscount { get; set; }
        public Schedule schedule { get; set; }

        public int totalNormalTickets { get; set; }
        public int totalChildTickets { get; set; }
        public int totalStudentTickets { get; set; }
        public int totalSeniorTickets { get; set; }

        // Website specific data
        public int total3DTickets { get; set; }
        public int totalPopcornTickets { get; set; }
        public int totalLadiesNightTickets { get; set; }

    }
}