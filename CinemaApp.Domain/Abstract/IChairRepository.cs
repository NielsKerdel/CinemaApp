using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Abstract
{
    public interface IChairRepository
    {
        IEnumerable<Chair> Chairs { get; }

        List<Chair> allChairsBySchedule(int scheduleID);
    }
}
