using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore001.Models;

namespace NetCore001.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Ali()
        {
            ViewData["Message"] = "Aqui empezamos a diseñar.";

            return View();
        }
        public IActionResult Ali_01()
        {
            ViewData["Message"] = "Seleccion.";

            return View();
        }
        public IActionResult Ali_02()
        {
            ViewData["Message"] = "Formato FDA";

            return View();
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
