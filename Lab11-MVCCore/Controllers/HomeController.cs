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
        /// <summary>
        /// HTTP GET request action
        /// </summary>
        /// <returns>The view for an index get request</returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// HTTP Post requestion action (when you submit with the button
        /// </summary>
        /// <param name="begYear">The beginning year</param>
        /// <param name="endYear">the end year</param>
        /// <returns>Returns the view from the results</returns>
        [HttpPost]
        public IActionResult Index(int begYear, int endYear)
        {
            // redirects to the result action with the parameters
            return RedirectToAction("Result", new { begYear, endYear });
        }
        
        /// <summary>
        /// The results page gets displayed
        /// </summary>
        /// <param name="begYear">The beginning year</param>
        /// <param name="endYear">The End year</param>
        /// <returns>The results of people that match that year</returns>
        public IActionResult Result(int begYear, int endYear)
        {
            // Creates a list of TimePerson that match
            List<TimePerson> list = TimePerson.GetPersons(begYear, endYear);
            return View(list);
        }
    }
}
