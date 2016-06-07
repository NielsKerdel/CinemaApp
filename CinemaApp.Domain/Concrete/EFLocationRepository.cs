using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Concrete
{
    public class EFLocationRepository : ILocationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Location> Locations
        {
            get
            {
                return context.Locations.ToList();
            }
        }
    }
}
