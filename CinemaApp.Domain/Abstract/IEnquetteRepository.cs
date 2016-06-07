using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Abstract
{
    public interface IEnquetteRepository
    {
        IEnumerable<Enquette> Enquettes { get; }

        void SaveEnquette(Enquette enquette);
    }
}
