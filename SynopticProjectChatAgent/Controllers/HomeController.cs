using Dapper;
using Microsoft.AspNetCore.Mvc;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using SynopticProjectChatAgent.Helper;

namespace SynopticProjectChatAgent.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Holiday> holiday = new List<Holiday>();
        private Holiday userInput = new Holiday();
        private DataConnection connection = new DataConnection();
        private UiHolidayModel model = new UiHolidayModel();
        private FilterOptions filter = new FilterOptions();
        private InputValidation validator = new InputValidation();
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
            if (validator.ValidateInput(continent,filter.ContinentsList,"SelectCategory")==true)
            {
                userInput.Continent = continent;
                HttpContext.Session.SetString("Continent",userInput.Continent);
                return View("SelectCategory");

            }
            return View("InvalidContinent");

        }


        [HttpPost] 
        public ActionResult SelectCategory(string category) 
        {
            if (validator.ValidateInput(category, filter.CategoryList, "SelectCategory") == true)
            {
                userInput.Category = category;
                HttpContext.Session.SetString("Category", userInput.Category);
                return View("SelectLocation");
            }
            else return View("InvalidCategory");

        }

        [HttpPost]
        public ActionResult SelectLocation(string location)
        {
            if (validator.ValidateInput(location, filter.LocationList, "SelectLocation") == true)
            {
                userInput.Location = location;
                HttpContext.Session.SetString("Location", userInput.Location);
                return View("SelectTempRating");
            }
            return View("InvalidLocation");
        }

        [HttpPost]
        public ActionResult SelectTempRating(string tempRating)
        {
 
            
            if (validator.ValidateInput(tempRating, filter.TempRatingList, "SelectTempRating") == true)
            {
                var continent = HttpContext.Session.GetString("Continent");
                var category = HttpContext.Session.GetString("Category");
                var location = HttpContext.Session.GetString("Location");
                userInput.TempRating = tempRating;

                return View("FilteredResults", connection.GetFilteredHolidays(holiday, continent, category, location, tempRating));
            }

            return View("InvalidTempRating");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}