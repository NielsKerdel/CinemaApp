using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaApp.Domain.Entities;

namespace CinemaApp.WebUI.Models
{
    public class DayOverviewModel
    {
        public List<Schedule> schedules { get; set; }
        public List<Kijkwijzer> kijkwijzer { get; set; }
        public IEnumerable<Movie> movies { get; set; }
        public int amountAdded { get; set; }

    }
}