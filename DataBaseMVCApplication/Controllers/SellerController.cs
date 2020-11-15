using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class SellerController : Controller
    {
        Services.Services services = new Services.Services();
        // GET: Seller
        public ActionResult Index()
        {
            var sellers = services.sellerService.GetSellers().Select(e => new SellerViewModel()
            {
                Email = e.Email,
                FIO = e.FIO,
                Id = e.Id,
                PercentFromOrder = e.PercentFromOrder,
                Phone = e.Phone
            }).ToList();
            return View(sellers);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Show(long sellerId)
        {
            var seller = services.sellerService.GetSeller(sellerId);

            return View(new SellerViewModel()
            {
                Id = sellerId,
                Email = seller.Email,
                FIO = seller.FIO,
                PercentFromOrder = seller.PercentFromOrder,
                Phone = seller.Phone
            });
        }

        [HttpPost]
        public RedirectToRouteResult Add(SellerViewModel sellerViewModel, string PercentFromOrder)
        {
            var sellerDto = new SellerDto()
            {
                Email = sellerViewModel.Email,
                FIO = sellerViewModel.FIO,
                PercentFromOrder = double.Parse(PercentFromOrder, CultureInfo.InvariantCulture),
                Phone = sellerViewModel.Phone
            };
            services.sellerService.AddSeller(sellerDto);
            return RedirectToRoute(new { controller = "Seller", action = "index" });
        }

        public ActionResult Edit(long sellerId)
        {
            var seller = services.sellerService.GetSeller(sellerId);
            return View(new SellerViewModel()
            {
                Id = seller.Id,
                Email = seller.Email,
                FIO = seller.FIO,
                PercentFromOrder = seller.PercentFromOrder,
                Phone = seller.Phone
            });
        }

        [HttpPost]
        public ActionResult Edit(SellerViewModel seller)
        {
            services.sellerService.UpdateSeller(new SellerDto()
            {
                Email = seller.Email,
                FIO = seller.FIO,
                Id = seller.Id,
                PercentFromOrder = seller.PercentFromOrder,
                Phone = seller.Phone
               
            });
            return View(seller);
        }
    }
}