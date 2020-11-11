using DataBaseMVCApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class ManufactorController : Controller
    {
        ManufactorService manufactorService = new ManufactorService();
        // GET: Manufactor
        public ActionResult Index()
        {
            var manufactors = manufactorService.GetManufactors();
            return View();
        }
    }
}