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
        public RedirectToRouteResult Add(HttpPostedFileBase UploadImage, WindowViewModel window)
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
            return RedirectToRoute(new { controller="Home",action="Index"});
        }

        public ActionResult Edit(long id)
        {
            var window = services.windowsServices.GetWindow(id);
            var windowVM = new WindowViewModel()
            {
                Color = window.Color,
                Description = window.Description,
                Having = window.Having,
                Id = window.Id,
                Image = window.Image,
                ManufactorId = window.ManufactorId,
                ManufactorName = window.Manufactor.Name,
                Price = window.Price
            };
            return View(windowVM);
        }

        [HttpPost]
        public ActionResult Edit(WindowViewModel windowViewModel, HttpPostedFileBase UploadImage)
        {

            var windowDto = new WindowDto()
            {
                Color = windowViewModel.Color,
                Description = windowViewModel.Description,
                Having = windowViewModel.Having,
                Id = windowViewModel.Id,
                ManufactorId = windowViewModel.ManufactorId,
                Price = windowViewModel.Price
            };
            byte[] array;
            if (UploadImage != null)
            {
                using (var stream = new BinaryReader(UploadImage.InputStream))
                {
                    array = stream.ReadBytes(UploadImage.ContentLength);
                }
                windowDto.Image = array;
                windowViewModel.Image = array;
            }
            else
            {
                var image = services.windowsServices.GetWindow(windowDto.Id).Image;
                windowDto.Image = image;
                windowViewModel.Image = image;
            }
            services.windowsServices.EditWindow(windowDto);

            return View(windowViewModel);
        }
    }
}