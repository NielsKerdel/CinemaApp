using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Concrete
{
    public class EFGenreRepository : IGenreRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Genre> Genres
        {
            get
            {
                return context.Genres.ToList();
            }
        }
    }
}
