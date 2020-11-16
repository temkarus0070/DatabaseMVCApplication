using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class OrderPositionController : Controller
    {
        private Services.Services services = new Services.Services();
        public void Delete(long orderPositionId)
        {
            services.orderPositionService.DeleteOrderPosition(orderPositionId);

        }


        public void Add(OrderPositionViewModel orderPositions)
        {
                services.orderPositionService.AddOrderPosition(new Services.OrderPositionDto()
                {
                    Length = orderPositions.Length,
                    OrderId = orderPositions.OrderId,
                    Width = orderPositions.Width,
                    WindowId = orderPositions.WindowId
                });
            }

        public void Update(OrderPositionViewModel orderPosition)
        {
            services.orderPositionService.UpdateOrderPosition(new Services.OrderPositionDto()
            {
                Id = orderPosition.Id,
                Length = orderPosition.Length,
                OrderId = orderPosition.OrderId,
                Width = orderPosition.Width,
                WindowId = orderPosition.WindowId
            });
        }
    }
}