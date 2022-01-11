using Dapper;
using Microsoft.AspNetCore.Mvc;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;

namespace SynopticProjectChatAgent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Holiday> holiday = new List<Holiday>();
        private Holiday userInput = new Holiday();
        //private string dbConnectionString = "Data Source=.;Initial Catalog=ProjectCDatabase;Integrated Security=True";
        private DataConnection connection = new DataConnection();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ViewAll()
        {
            return View(connection.GetAllHolidays(holiday));
        }


        [HttpPost]
        public ActionResult SelectContinent(string continent)
        {
            //Holiday hol = new Holiday();
            //hol.Continent = continent;
            userInput.Continent = continent;
            TempData["Continent"] = continent;
            return View("SelectCategory");
        }

        [HttpPost] 
        public ActionResult SelectCategory(string category) 
        {
            userInput.Category= category;
            TempData["Category"] = category;
            return View("SelectLocation");
        }

        public ActionResult SelectContinent() 
        {
            return View();
        }

        public ActionResult SelectCategory() 
        {
            return View("");
        }

        [HttpPost]
        public ActionResult SelectLocation(string location)
        {
            userInput.Location= location;
            TempData["Location"] = location;
            return View("SelectTempRating");
        }

        public ActionResult SelectLocation() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectTempRating(string tempRating)
        {
            userInput.TempRating = tempRating;
            TempData["TempRating"] = tempRating;
            return View("FilteredResults");
        }

        public ActionResult SelectTempRating()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FilteredResults() 
        {

            var continent = TempData["Continent"];
            var category = TempData["Category"];
            var location = TempData["Location"];
            var tempRating = TempData["TempRating"];

            if (ModelState.IsValid)
            {
                //return View(connection.GetFilteredHolidays(holiday, "Europe", "active", "sea", "mild"));

                //return View(connection.GetFilteredHolidays(holiday,continent,category,location,tempRating));
            }
            return View();
        }

        public ActionResult HolidayInput()
        {
            return View();
        }
         

        public IActionResult Index()
        {
            HttpContext.Session.SetString("TEst", "Session Value");
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.sessionv = HttpContext.Session.GetString("Test");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}