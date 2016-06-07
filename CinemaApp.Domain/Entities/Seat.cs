using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Seat
    {
        public int ID { get; set; }
        public int SeatID { get; set; }
        [ForeignKey("RowID")]
        public int RowFK { get; set; }
        public virtual Row RowID { get; set; }


        [ForeignKey("HallID")]
        public int HallFK { get; set; }
        public virtual Hall HallID { get; set; }


    }
}