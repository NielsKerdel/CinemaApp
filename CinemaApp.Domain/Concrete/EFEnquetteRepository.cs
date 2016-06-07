using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Concrete
{
    public class EFEnquetteRepository : IEnquetteRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Enquette> Enquettes
        {
            get
            {
                return context.Enquettes;
            }
        }

        public void SaveEnquette(Enquette enquette)
        {
            if (enquette.ID == 0)
            {
                context.Enquettes.Add(enquette);
            }
            else {
                Enquette dbEntry = context.Enquettes.Find(enquette.ID);
                if (dbEntry != null)
                {
                    dbEntry.ID = enquette.ID;
                    dbEntry.Name = enquette.Name;
                    dbEntry.Description = enquette.Description;
                }
            }
            context.SaveChanges();
        }
    }
}
