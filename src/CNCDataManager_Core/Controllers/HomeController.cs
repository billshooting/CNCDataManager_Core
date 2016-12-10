using Microsoft.AspNetCore.Mvc;
using System;

namespace CNCDataManager.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}