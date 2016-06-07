using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CinemaApp.Domain.Concrete
{
    public class EFChairRepository : IChairRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Chair> Chairs
        {
            get
            {
                return context.Chairs;
            }
        }

        public List<Chair> allChairsBySchedule(int scheduleID)
        {
            return context.Chairs.Where(p => p.ScheduleFK == scheduleID).Include("SeatID").ToList();
        }
    }
}
