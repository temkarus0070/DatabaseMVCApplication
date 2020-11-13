using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class BuyerController : Controller
    {
        private Services.Services services = new Services.Services();
        // GET: Buyer
        public ActionResult Index()
        {
            var buyers = services.buyerService.GetBuyers().Select(model => new BuyerViewModel()
            {
                FIO = model.FIO,
                IsLegalEntity = model.IsLegalEntity,
                Phone = model.Phone,
                Id = model.Id
            }).ToList();
            return View(buyers);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Add(BuyerViewModel buyerViewModel)
        {
            services.buyerService.AddBuyer(new Services.BuyerDto()
            {
                FIO = buyerViewModel.FIO,
                IsLegalEntity = buyerViewModel.IsLegalEntity,
                Phone = buyerViewModel.Phone
            });
            return RedirectToRoute(new { controller = "Buyer", action = "Index" });
        }

        public ActionResult Show(long buyerId)
        {
            var buyer = services.buyerService.GetBuyer(buyerId);
            return View(new BuyerViewModel()
            {
                FIO = buyer.FIO,
                Id = buyer.Id,
                IsLegalEntity = buyer.IsLegalEntity,
                Phone = buyer.Phone,
                Orders = services.orderService.GetOrders().Where(e => e.BuyerId == buyerId).Select(e => new OrderViewModel()
                {
                    Id = e.Id,
                    DeliverDate = e.DeliverDate,
                    IsDeliver = e.IsDeliver,
                    IsSetup = e.IsSetup,
                    OrderDate = e.OrderDate,
                    Price = e.Price,
                    SetupDate = e.SetupDate
                }).ToList()
            });
        }

        public ActionResult Edit(long buyerId)
        {
            var buyer = services.buyerService.GetBuyer(buyerId);
            return View(new BuyerViewModel()
            {
                FIO = buyer.FIO,
                Id = buyer.Id,
                IsLegalEntity = buyer.IsLegalEntity,
                Phone = buyer.Phone,
                
            });
        }

        [HttpPost]
        public ActionResult Edit(BuyerViewModel buyerViewModel)
        {
            services.buyerService.EditBuyer(new Services.BuyerDto()
            {
                FIO = buyerViewModel.FIO,
                Id = buyerViewModel.Id,
                Phone = buyerViewModel.Phone,
                IsLegalEntity = buyerViewModel.IsLegalEntity
            });
            return View(buyerViewModel);
        }
    }
}