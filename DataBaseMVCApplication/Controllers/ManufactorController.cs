using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class ManufactorController : Controller
    {
        Services.Services services = new Services.Services();
        // GET: Manufactor
        public ActionResult Index()
        {
            var manufactors = services.manufactorService.GetManufactors().Select(manufactor => new ManufactorViewModel()
            {
                Address = manufactor.Address,
                Email = manufactor.Email,
                Name = manufactor.Name,
                Phone = manufactor.Phone,
                Id = manufactor.Id
            }).ToList();
            return View(manufactors);
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Show(long manufactorId)
        {
            var manufactor = services.manufactorService.GetManufactor(manufactorId);
            var manufactorVM = new ManufactorViewModel()
            {
                Address = manufactor.Address,
                Email = manufactor.Email,
                Id = manufactor.Id,
                Name = manufactor.Name,
                Phone = manufactor.Phone
            };
            return View(manufactorVM);
        }
        [HttpPost]
        public RedirectToRouteResult Add(ManufactorViewModel manufactor)
        {
            var manufactorDto = new ManufactorDto()
            {
                Address = manufactor.Address,
                Email = manufactor.Email,
                Name = manufactor.Name,
                Phone = manufactor.Phone
            };
            services.manufactorService.AddManufactor(manufactorDto);
            return RedirectToRoute(new { controller = "Manufactor", action = "Index" });
        }

        public ActionResult Edit(long manufactorId)
        {
            var manufactor = services.manufactorService.GetManufactor(manufactorId);
            return View(new ManufactorViewModel()
            {
                Id = manufactor.Id,
                Address = manufactor.Address,
                Email = manufactor.Email,
                Name = manufactor.Name,
                Phone = manufactor.Phone
            });
        }
        [HttpPost]
        public ActionResult Edit(ManufactorViewModel manufactorViewModel)
        {
            services.manufactorService.EditManufactor(new ManufactorDto()
            {
                Id = manufactorViewModel.Id,
                Address = manufactorViewModel.Address,
                Email = manufactorViewModel.Email,
                Name = manufactorViewModel.Name,
                Phone = manufactorViewModel.Phone
            });
            return View(manufactorViewModel);
        }

        public void Delete(string manufactorId)
        {
            long id = long.Parse(manufactorId);
            services.manufactorService.DeleteManufactor(id);
        }
    }
}