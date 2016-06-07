using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("movie")]
        public int movieFK { get; set; }
        public virtual Movie movie { get; set; }
        [ForeignKey("hall")]
        public int hallFK { get; set; }
        public virtual Hall hall { get; set; }
        public int AvailableSeats { get; set; }
        public bool isHoliday { get; set; }
         
    }
}
