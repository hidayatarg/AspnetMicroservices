using Aspnetrun.Data;
using Aspnetrun.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aspnetrun.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        protected readonly AspnetrunContext _dbContext;

        public OrderRepository(AspnetrunContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Order> CheckOut(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                            .Where(o => o.UserName == userName)
                            .ToListAsync();

            return orderList;
        }
    }
}
