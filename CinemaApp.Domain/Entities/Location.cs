using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Entities
{
    public class Location
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String City { get; set; }
        public String Address { get; set; }
        public String ZipCode { get; set; }
        public String Phone { get; set; }
        public String Mail { get; set; }
        public String Website { get; set; }
    }
}
