using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Infractracure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
   public class OrderService
    {
        private BaseRepository<Order> orderRepository;
        private WindowsDatabaseContext context;

        public OrderService()
        {
            context = new WindowsDatabaseContext();
            this.orderRepository = new BaseRepository<Order>(context);
        }

        public void AddOrder(Order order,Buyer buyer,Seller seller)
        {
            order.Buyer = buyer;
            order.Seller = seller;
            orderRepository.Create(order);
        }

        public void EditOrder(Order order)
        {
            orderRepository.Update(order);
        }

        public void DeleteOrder(Order order)
        {
            orderRepository.Delete(order);
        }
    }
}
