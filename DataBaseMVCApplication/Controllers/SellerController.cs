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

        [HttpPost]
        public ActionResult Add(SellerViewModel sellerViewModel,string PercentFromOrder)
        {
            var sellerDto = new SellerDto()
            {
                Email = sellerViewModel.Email,
                FIO = sellerViewModel.FIO,
                PercentFromOrder = double.Parse(PercentFromOrder, CultureInfo.InvariantCulture),
                Phone = sellerViewModel.Phone
            };
            services.sellerService.AddSeller(sellerDto);
            return View("Index");
        }
    }
}