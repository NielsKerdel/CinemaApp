using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Hall
    {
        public int Id { get; set; }
        [ForeignKey("CinemaID")]
        public int LocationFK { get; set; }
        public virtual Location CinemaID { get; set; }
        public int TotalRows { get; set; }
        public int TotalSeats { get; set; }
        public string Name { get; set; }
        public bool WheelchairAccesibility { get; set; }
    }
}
