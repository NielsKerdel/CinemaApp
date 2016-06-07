using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Chair
    {
        public int ID { get; set; }
        [ForeignKey("SeatID")]
        public int SeatFK { get; set; }
        public virtual Seat SeatID { get; set; }
        [ForeignKey("ScheduleID")]
        public int ScheduleFK { get; set; }
        public virtual Schedule ScheduleID { get; set; }
        public int Reservation { get; set; }
    }
}
