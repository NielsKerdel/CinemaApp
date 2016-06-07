using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Concrete
{
   public class EFMovieRepository : IMovieRepository
    {
       private EFDbContext context = new EFDbContext();

        public IEnumerable<Movie> Movies
        {

            get
            {
                return context.Movies;
            }
        }
    }
}
