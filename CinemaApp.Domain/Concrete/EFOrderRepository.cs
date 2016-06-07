using CinemaApp.Domain.Abstract;
using CinemaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Domain.Concrete
{
    [ExcludeFromCodeCoverage]
    public class EFOrderRepository : IOrderRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders;
            }

        }

        public void saveOrder(int OrderNumber, Schedule schedule, Ticket[] ticketsList)
        {
            throw new NotImplementedException();
        }

        // this method contains no 'else' because we do not allow people to edit their order.
        //public void saveOrder(int OrderNumber, Schedule schedule, Ticket[] ticketsList)
        //{
        //    bool DoesntExist = context.Orders.FirstOrDefault(o => o.OrderCode == OrderNumber) == null;

        //    if (DoesntExist)
        //    {
        //        Order newOrder = new Order();
        //        newOrder.OrderCode = OrderNumber;
        //        newOrder.Schedule = schedule;
        //        newOrder.tickets = ticketsList;
        //        newOrder.Paid = true;

        //        context.Orders.Add(newOrder);
        //    }

        //    context.SaveChanges();
        //}



    }
}