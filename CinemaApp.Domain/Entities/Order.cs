using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Order
    {
        public int ID { get; set; }
        public int OrderCode { get; set; }
        [ForeignKey("Schedule")]
        public int ScheduleFK { get; set; }
        public virtual Schedule Schedule { get; set; }

        public int TicketFK { get; set; }
        public virtual Ticket[] tickets { get; set; }

        public Boolean Paid { get; set; }
    }
}