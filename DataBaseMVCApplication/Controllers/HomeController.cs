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
        private Services.Services services = new Services.Services();
        public ActionResult Index(int? manufactorId)
        {
            var manufactors = services.manufactorService.GetManufactors().Select(e => new ManufactorViewModel()
            {
                Address = e.Address,
                Email = e.Email,
                Id = e.Id,
                Name = e.Name,
                Phone = e.Phone
            }).ToList();

            manufactors.Insert(0, new ManufactorViewModel() { Id = 0, Name = "Все" });
            var windows = services.windowsServices.GetWindows();
            var windowsViewModelList = new List<WindowViewModel>();
            if (manufactorId == null || manufactorId == 0)
            {
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
            }
            else
            {
                windowsViewModelList = windows.Where(e => e.ManufactorId == manufactorId).Select(window => new WindowViewModel()
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
            }
            return View((windowsViewModelList, manufactors));
        }

        public ActionResult Show(long index)
        {
            var window = services.windowsServices.GetWindow(index);
            var windowVM = new WindowViewModel()
            {
                Color = window.Color,
                Description = window.Description,
                Having = window.Having,
                Id = window.Id,
                Image = window.Image,
                ManufactorId = window.ManufactorId,
                Price = window.Price,
                ManufactorName = window.Manufactor.Name
            };
            return View(windowVM);
        }



    }
}