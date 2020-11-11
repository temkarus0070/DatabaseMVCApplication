using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DataBaseMVCApplication.Controllers
{
    public class WindowController : Controller
    {
        private Services.Services services = new Services.Services();

        // GET: Window
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            var manufactors = services.manufactorService.GetManufactors().Select(model => new ManufactorViewModel()
            {
                Name = model.Name,
                Id = model.Id
            }).ToList();
            return View((new WindowViewModel(), manufactors));
        }

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase UploadImage, WindowViewModel window)
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(UploadImage.InputStream))
            {
                imageData = binaryReader.ReadBytes(UploadImage.ContentLength);
            }
            WindowDto windowDto = new WindowDto()
            {
                Color = window.Color,
                Description = window.Description,
                Image = imageData,
                Having = window.Having,
                ManufactorId = window.ManufactorId,
                Price = window.Price
            };
            services.windowsServices.AddWindow(windowDto);
            return View();
        }
    }
}