using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Ticket
    {
        public int ID { get; set; }
        [ForeignKey("ticketMovie")]
        public int MovieFK { get; set; }
        public virtual Movie ticketMovie { get; set; }
        [ForeignKey("ticketHall")]
        public int HallFK { get; set; }
        public virtual Hall ticketHall { get; set; }
        [ForeignKey("ticketRow")]
        public int RowFK { get; set; }
        public virtual Row ticketRow { get; set; }
        [ForeignKey("ticketSeat")]
        public int SeatFK { get; set; }
        public virtual Seat ticketSeat { get; set; }
        [ForeignKey("ticketRate")]
        public int RateFK { get; set; }
        public virtual Rate ticketRate { get; set; }
        public int OrderCode { get; set; }
        [ForeignKey("ticketSchedule")]
        public int ScheduleFK { get; set; }
        public virtual Schedule ticketSchedule { get; set; }
    }
}
