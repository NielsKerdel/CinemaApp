using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaApp.Domain.Entities;

namespace CinemaApp.WebUI.Models
{
    public class KijkwijzerViewModel
    {
        public Movie movie { get; set; }
        public List<Kijkwijzer> kijkwijzer { get; set; }

    }
}