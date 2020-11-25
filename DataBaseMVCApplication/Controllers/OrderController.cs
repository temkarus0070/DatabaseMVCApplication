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
            int orderData = services.orderService.GetOrders().Count();
            var orders = services.orderService.GetOrders().Select(e =>
            {
                var buyer = services.buyerService.GetBuyer(e.BuyerId);
                var seller = services.sellerService.GetSeller(e.SellerId);
                return new OrderViewModel()
                {
                    Id = e.Id,
                    DeliverDate = e.DeliverDate,
                    IsDeliver = e.IsDeliver,
                    IsSetup = e.IsSetup,
                    OrderDate = e.OrderDate,
                    Price = e.Price,
                    SetupDate = e.SetupDate,
                    BuyerId = e.BuyerId,
                    SellerId = e.SellerId,
                    Buyer = new BuyerViewModel()
                    {
                        FIO = buyer.FIO,
                        Id = buyer.Id,
                        IsLegalEntity = buyer.IsLegalEntity,
                        Phone = buyer.Phone
                    }
                    ,
                    Seller = new SellerViewModel()
                    {
                        Email = seller.Email,
                        FIO = seller.FIO,
                        Id = seller.Id,
                        Phone = seller.Phone
                    }
                };
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
                Price = e.Price,
                ManufactorName = e.Manufactor.Name,
                 Model=e.Model


            });
            windows.OrderBy(e => e.ManufactorName);

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
            return View((new OrderViewModel(), buyers, sellers, windows));
        }

        [HttpPost]
        public RedirectToRouteResult Add(OrderViewModel orderViewModel, List<OrderPositionViewModel> orderPositions, string Price)
        {
            orderViewModel.OrderDate = DateTime.Now;
            var index = services.orderService.AddOrder(new Services.OrderDto()
            {
                BuyerId = orderViewModel.BuyerId,
                IsDeliver = orderViewModel.IsDeliver,
                IsSetup = orderViewModel.IsSetup,
                OrderDate = orderViewModel.OrderDate,
                Price = Price != null ? double.Parse(Price, CultureInfo.InvariantCulture) : 0,
                SellerId = orderViewModel.SellerId,
                DeliverDate = orderViewModel.DeliverDate,
                SetupDate = orderViewModel.SetupDate
            });
            foreach (var e in orderPositions)
            {
                services.orderPositionService.AddOrderPosition(new Services.OrderPositionDto()
                {
                    Length = e.Length,
                    OrderId = index,
                    Width = e.Width,
                    WindowId = e.WindowId
                });
            }
            return RedirectToAction("Index");
        }

        public ActionResult Show(long orderId)
        {
            var order = services.orderService.GetOrder(orderId);
            var orderPositions = services.orderPositionService.GetOrderPositions(orderId).Select(e => new OrderPositionViewModel()
            {
                Id = e.Id,
                Length = e.Length,
                OrderId = e.OrderId,
                WindowId = e.WindowId,
                Width = e.Width,
                Window = new WindowViewModel()
                {
                    Color = e.Window.Color,
                    Description = e.Window.Description,
                    Having = e.Window.Having,
                    Id = e.Window.Id,
                    Image = e.Window.Image,
                    ManufactorName = e.Window.Manufactor.Name,
                    Price = e.Window.Price,
                     Model=e.Window.Model
                }
            });
            var orderVM = new OrderViewModel()
            {
                BuyerId = order.BuyerId,
                DeliverDate = order.DeliverDate,
                Id = orderId,
                IsDeliver = order.IsDeliver,
                IsSetup = order.IsSetup,
                OrderDate = order.OrderDate,
                Price = order.Price,
                SellerId = order.SellerId,
                SetupDate = order.SetupDate,
                Buyer = new BuyerViewModel()
                {
                    FIO = order.Buyer.FIO,
                    Id = order.Buyer.Id,
                    IsLegalEntity = order.Buyer.IsLegalEntity,
                    Phone = order.Buyer.Phone
                },
                Seller = new SellerViewModel()
                {
                    Email = order.Seller.Email,
                    FIO = order.Seller.FIO,
                    Id = order.Seller.Id,
                    PercentFromOrder = order.Seller.PercentFromOrder,
                    Phone = order.Seller.Phone
                },
            };
            return View((orderVM, orderPositions));
        }

        public ActionResult Edit(long orderId)
        {

            var buyerName = "";
            var sellerName = "";
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
                Price = e.Price,
                ManufactorName = e.Manufactor.Name,
                Model = e.Model


            });
            windows.OrderBy(e => e.ManufactorName);

            var order = services.orderService.GetOrder(orderId);
            var orderPositions = services.orderPositionService.GetOrderPositions(orderId);
            var orderPositionsVM = orderPositions.Select(e => new OrderPositionViewModel()
            {
                Id = e.Id,
                Length = e.Length,
                OrderId = e.OrderId,
                Width = e.Width,
                WindowId = e.WindowId,
                Window = new WindowViewModel()
                {
                    Color = e.Window.Color,
                    Description = e.Window.Description,
                    Having = e.Window.Having,
                    Id = e.Window.Id,
                    Image = e.Window.Image,
                    ManufactorId = e.Window.ManufactorId,
                    ManufactorName = e.Window.Manufactor.Name,
                    Price = e.Window.Price,
                     Model=e.Window.Model
                }
            }).ToList();
            var orderData = new OrderViewModel()
            {
                DeliverDate = order.DeliverDate,
                IsDeliver = order.IsDeliver,
                IsSetup = order.IsSetup,
                OrderDate = order.OrderDate,
                Id = order.Id,
                Price = order.Price,
                SetupDate = order.SetupDate,
                Buyer = new BuyerViewModel()
                {
                    FIO = order.Buyer.FIO,
                    Id = order.Buyer.Id,
                    IsLegalEntity = order.Buyer.IsLegalEntity,
                    Phone = order.Buyer.Phone
                },
                BuyerId = order.BuyerId,
                Seller = new SellerViewModel()
                {
                    Email = order.Seller.Email,
                    FIO = order.Seller.FIO,
                    Id = order.Seller.Id,
                    PercentFromOrder = order.Seller.PercentFromOrder,
                    Phone = order.Seller.Phone
                },
                SellerId = order.SellerId,
                OrderPositions = orderPositionsVM
            };

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
                if (buyer.Id == order.BuyerId)
                {
                    buyerName = buyer.FIO;
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
                if (seller.Id == order.SellerId)
                {
                    sellerName = seller.FIO;
                }
            }

            ViewBag.SellerName = sellerName;
            ViewBag.BuyerName = buyerName;
            return View((orderData, buyers, sellers, windows));
        }


        [HttpPost]
        public void Edit(OrderViewModel order, string Price)
        {
            services.orderService.EditOrder(new Services.OrderDto()
            {
                BuyerId = order.BuyerId,
                DeliverDate = order.DeliverDate,
                Id = order.Id,
                IsDeliver = order.IsDeliver,
                IsSetup = order.IsSetup,
                OrderDate = order.OrderDate,
                Price = double.Parse(Price, CultureInfo.InvariantCulture),
                SellerId = order.SellerId,
                SetupDate = order.SetupDate
            });
        }

        public void Delete(string orderId)
        {
            long id = long.Parse(orderId);
            services.orderService.DeleteOrder(id);
        }


    }
}