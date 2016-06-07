using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Abstract
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> Movies { get; }
    }
}