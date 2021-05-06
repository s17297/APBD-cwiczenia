using cwiczenia_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia_5.Services
{
    interface IWarehouseRequest
    {
        public IEnumerable<Order> GetOrders();
        public IEnumerable<Order> CreateOrder();
    }
}
