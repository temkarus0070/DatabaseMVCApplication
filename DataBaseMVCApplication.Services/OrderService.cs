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

        public void AddOrder(OrderDto orderDto)
        {
            repositories.orderRepository.Create(Convert(orderDto,false));
        }

        public void EditOrder(OrderDto orderDto)
        {
            repositories.orderRepository.Update(Convert(orderDto,true));
        }

        public void DeleteOrder(OrderDto orderDto)
        {
            repositories.orderRepository.Delete(Convert(orderDto,true));
        }

        private Order Convert(OrderDto orderDto,bool isUpdate)
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
