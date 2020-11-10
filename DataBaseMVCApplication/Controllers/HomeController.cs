using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private WindowsServices windowsServices = new WindowsServices();
        public ActionResult Index()
        {
            var windows = windowsServices.GetWindows();
            var windowsViewModelList = new List<WindowViewModel>();
            windowsViewModelList = windows.Select(window => new WindowViewModel()
            {
                Color = window.Color,
                Description = window.Description,
                Having = window.Having,
                Id = window.Id,
                Image = window.Image,
                ManufactorId = window.ManufactorId,
                ManufactorName = window.Manufactor.Name,
                Price = window.Price
            }).ToList();
            return View(windowsViewModelList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}