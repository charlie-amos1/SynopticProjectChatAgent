using Dapper;
using Microsoft.AspNetCore.Mvc;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

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
            return View("SelectCategory");
        }

        [HttpPost] 
        public ActionResult SelectCategory(string category) 
        {
            userInput.Category= category;
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
            return View("SelectStarRating");
        }

        public ActionResult SelectLocation() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectStarRating(string starRating)
        {
            userInput.StarRating = Convert.ToInt32(starRating);
            return View("FilteredResults");
        }

        public ActionResult SelectStarRating()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FilteredResults(string continent, string category, string location, string tempRating) 
        {
            continent = userInput.Continent;
            category = userInput.Category;
            location = userInput.Location;
            tempRating = userInput.TempRating;
            //continent = "Europe";
            // category = "active";
            // location = "sea";
            // tempRating = "mild";

            if (ModelState.IsValid)
            {
                return View(connection.GetFilteredHolidays(holiday,continent,category,location,tempRating));
            }
            return View();
        }

        public ActionResult HolidayInput()
        {
            return View();
        }
         

        public IActionResult Index()
        {
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
    }
}