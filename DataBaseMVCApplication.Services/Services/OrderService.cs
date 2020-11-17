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
        private Repositories repositories;

        public OrderService()
        {
            repositories = new Repositories();
        }

        public IEnumerable<OrderDto> GetOrders()
        {
            return repositories.orderRepository.Get().Select(e => new OrderDto()
            {
                BuyerId = e.BuyerId,
                DeliverDate = e.DeliverDate,
                IsDeliver = e.IsDeliver,
                IsSetup = e.IsSetup,
                OrderDate = e.OrderDate,
                Price = e.Price,
                SellerId = e.SellerId,
                SetupDate = e.SetupDate,
                Id = e.Id
            });
        }

        public Order GetOrder(long id)
        {
            return repositories.orderRepository.GetById(id);
        }

        public long AddOrder(OrderDto orderDto)
        {
            var order = Convert(orderDto, false);
            repositories.orderRepository.Create(order);
            return order.Id;

        }

        public void EditOrder(OrderDto orderDto)
        {
            repositories.orderRepository.Update(Convert(orderDto, true));
        }

        public void DeleteOrder(long id)
        {
            repositories.orderRepository.Delete(id);
        }

        private Order Convert(OrderDto orderDto, bool isUpdate)
        {
            Order order = new Order()
            {
                Buyer = repositories.buyerRepository.GetById(orderDto.BuyerId),
                BuyerId = orderDto.BuyerId,
                DeliverDate = orderDto.DeliverDate,
                IsDeliver = orderDto.IsDeliver,
                IsSetup = orderDto.IsSetup,
                OrderDate = orderDto.OrderDate,
                Price = orderDto.Price,
                Seller = repositories.sellerRepository.GetById(orderDto.SellerId),
                SellerId = orderDto.SellerId,
                SetupDate = orderDto.SetupDate,
                OrderPositions = orderDto.OrderPositions
            };
            if (isUpdate)
                order.Id = orderDto.Id;
            return order;
        }
    }
}
