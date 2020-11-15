using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class OrderController : Controller
    {
        Services.Services services = new Services.Services();
        // GET: Order
        public ActionResult Index()
        {
            var orders = services.orderService.GetOrders().Select(e => new OrderViewModel()
            {
                Id = e.Id,
                DeliverDate = e.DeliverDate,
                IsDeliver = e.IsDeliver,
                IsSetup = e.IsSetup,
                OrderDate = e.OrderDate,
                Price = e.Price,
                SetupDate = e.SetupDate
            });
            return View(orders);
        }

        public ActionResult Add()
        {
            var buyersData = services.buyerService.GetBuyers();
            var sellersData = services.sellerService.GetSellers();
            HashSet<BuyerViewModel> buyers = new HashSet<BuyerViewModel>();
            HashSet<SellerViewModel> sellers = new HashSet<SellerViewModel>();
            var windows = services.windowsServices.GetWindows().Select(e => new WindowViewModel()
            {
                Id = e.Id,
                Description = e.Description,
                Color = e.Color,
                Having = e.Having,
                Price = e.Price
            });

            foreach (var e in buyersData)
            {
                var buyer = new BuyerViewModel() { FIO = e.FIO, Id = e.Id };
                if (!buyers.Contains(buyer))
                    buyers.Add(buyer);
                else
                {
                    buyer.FIO += " " + e.Phone;
                    buyers.Add(buyer);
                }

            }
            foreach (var e in sellersData)
            {
                var seller = new SellerViewModel() { FIO = e.FIO, Id = e.Id };
                if (!sellers.Contains(seller))
                    sellers.Add(seller);
                else
                {
                    seller.FIO += " " + e.Phone;
                    sellers.Add(seller);
                }
            }
            return View((new OrderViewModel(), buyers, sellers,windows));
        }

        [HttpPost]
        public RedirectToRouteResult Add(OrderViewModel orderViewModel, List<OrderPositionViewModel> orderPositions)
        {
            var deliver = Request.Form["isDeliver"];
            var setup = Request.Form["IsSetup"];
            var price = Request.Form["Price"];
            orderViewModel.OrderDate = DateTime.Now;
            services.orderService.AddOrder(new Services.OrderDto()
            {
                BuyerId = orderViewModel.BuyerId,
                DeliverDate = orderViewModel.DeliverDate,
                IsDeliver = deliver == null ? false : true,
                IsSetup = setup == null ? false : true,
                OrderDate = orderViewModel.OrderDate,
                Price = price != null ? double.Parse(price, CultureInfo.InvariantCulture) : 0,
                SellerId = orderViewModel.SellerId,
                SetupDate = orderViewModel.SetupDate
            });
            var order = services.orderService.GetOrders().Where(e =>
            e.OrderDate == orderViewModel.OrderDate && e.Price == orderViewModel.Price &&
            e.SellerId == orderViewModel.SellerId && e.BuyerId == orderViewModel.BuyerId &&
            e.IsDeliver == orderViewModel.IsDeliver && e.IsSetup == orderViewModel.IsSetup).First();
            foreach (var e in orderPositions)
            {
                services.orderPositionService.AddOrderPosition(new Services.OrderPositionDto()
                {
                    Length = e.Length,
                    OrderId = order.Id,
                    Width = e.Width,
                    WindowId = e.WindowId
                });
            }
            return RedirectToAction("Index");
        }
    }
}