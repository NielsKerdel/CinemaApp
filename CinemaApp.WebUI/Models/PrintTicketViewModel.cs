using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.WebUI.Models
{
    public class PrintTicketViewModel
    {

        public List<Ticket> Tickets { get; set; }

        public Schedule schedule { get; set; }


    }
}