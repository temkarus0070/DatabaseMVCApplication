using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBaseMVCApplication.Services
{
    public class OrderPositionService
    {
        Repositories repositories;

        public OrderPositionService()
        {
            this.repositories = new Repositories();
        }

        public void AddOrderPosition(OrderPositionDto orderPositionDto)
        {
            repositories.orderPositionRepository.Create(Convert(orderPositionDto, true));
        }

        public void UpdateOrderPosition(OrderPositionDto orderPositionDto)
        {
            repositories.orderPositionRepository.Update(Convert(orderPositionDto,true));
        }

        public void DeleteOrderPosition(long id)
        {
            repositories.orderPositionRepository.Delete(id);
        }

        OrderPosition Convert(OrderPositionDto orderPositionDto, bool isUpdate)
        {
            OrderPosition orderPosition = new OrderPosition()
            {
                Length = orderPositionDto.Length,
                Order = repositories.orderRepository.GetById(orderPositionDto.OrderId),
                OrderId = orderPositionDto.OrderId,
                Width = orderPositionDto.Width,
                WindowId = orderPositionDto.WindowId,
                Window = repositories.windowRepository.GetById(orderPositionDto.WindowId)
            };
            if(isUpdate)
            {
                orderPosition.Id = orderPositionDto.Id;
            }
            return orderPosition;
        }
    }
}
