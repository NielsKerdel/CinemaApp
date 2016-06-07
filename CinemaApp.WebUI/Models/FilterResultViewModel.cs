using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaApp.WebUI.Models
{
    public class FilterResultViewModel
    {
        public string selectedMovie { get; set; }
        public DateTime? selectedDate { get; set; }
        public DateTime? selectedTime { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Movie> MovieList { get; set; }

        public Movie Movie { get; set; }
        public List<Kijkwijzer> Kijkwijzer { get; set; }
        public List<Schedule> Schedules { get; set; }

    }
}