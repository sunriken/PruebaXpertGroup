using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaXpertGroup.Models;

namespace PruebaXpertGroup.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Prueba .Net XpertGroup";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contacto";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Ejecutar()
        {
            ViewData["Codigo"] = HttpContext.Request.Form["formControlCodigoPrueba"];

            CubeOperationsParser parser = new CubeOperationsParser();

            string resultados = parser.ParseCode(ViewData["Codigo"].ToString());

            ViewData["Resultados"] = resultados;

            return View("Index");
        }
    }
}
