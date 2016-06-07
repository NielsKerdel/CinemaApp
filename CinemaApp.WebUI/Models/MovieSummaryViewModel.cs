using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.WebUI.Models
{
    public class MovieSummaryViewModel
    {
        public Movie Movie { get; set; }
        public Kijkwijzer[] Kijkwijzer { get; set; }
        public Schedule[] Schedules { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

       
    }
}