using Microsoft.AspNetCore.Mvc;
using Lab11_MVCCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab11_MVCCore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            return RedirectToAction("Result", new { begYear, endYear });
        }

        public IActionResult Result(int begYear, int endYear)
        {
            List<TimePerson> list = TimePerson.GetPersons(begYear, endYear);
            return View(list);
        }
    }
}
