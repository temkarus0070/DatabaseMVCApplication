using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class WindowController : Controller
    {
        private ManufactorService manufactorService = new ManufactorService();
        // GET: Window
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var manufactors = manufactorService.GetManufactors().Select(model => new ManufactorViewModel()
            {
                Name = model.Name,
                Id = model.Id
            }).ToList();
            return View((new WindowViewModel(), manufactors));
        }

        [HttpPost]
        public ActionResult Add(string manufactorId, HttpPostedFileBase UploadImage, WindowViewModel window)
        {
            return View();
        }
    }
}