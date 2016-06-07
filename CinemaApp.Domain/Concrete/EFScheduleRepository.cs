using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Concrete
{
    public class EFScheduleRepository : IScheduleRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Schedule> Schedules
        {
            get
            {
                return context.Schedules.ToList();
            }
        }
    }
}
