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

        [HttpPost]
        public ActionResult Add(ManufactorViewModel manufactor)
        {
            var manufactorDto = new ManufactorDto()
            {
                Address = manufactor.Address,
                Email = manufactor.Email,
                Name = manufactor.Name,
                Phone = manufactor.Phone
            };
            services.manufactorService.AddManufactor(manufactorDto);
            return View();
        }
    }
}