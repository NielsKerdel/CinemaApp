using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaApp.Domain.Entities;

namespace CinemaApp.Domain.Abstract
{
    public interface IOrderRepository
    {
        IEnumerable<Order> Orders { get; }

       // void saveOrder(int OrderNumber, Schedule schedule, Ticket[] ticketsList);
    }
}
