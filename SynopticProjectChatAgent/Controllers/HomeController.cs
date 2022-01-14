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


        //http post sends data from the view
        [HttpPost]
        public ActionResult SelectContinent(string continent)
        {
            //validate input checks the continent parameter against a list of continents to ensure its valid
            if (validator.ValidateInput(continent, filter.ContinentsList, "Continent") == true)
            {
                userInput.Continent = continent;
                //this saves the continent parameter in a string to be passed through to the filter method
                HttpContext.Session.SetString("Continent", userInput.Continent);
                //returns the view named select category
                return View("SelectCategory");

            }
            //returns the invalid view
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

        public ActionResult SelectContinent()
        {
            return View();
        }

        public ActionResult SelectCategory()
        {
            return View();
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

        public ActionResult SelectLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SelectTempRating(string tempRating)
        {


            if (validator.ValidateInput(tempRating, filter.TempRatingList, "SelectTempRating") == true)
            {
                //gets the strings that are saved into the session and saves them to a variable.
                var continent = HttpContext.Session.GetString("Continent");
                var category = HttpContext.Session.GetString("Category");
                var location = HttpContext.Session.GetString("Location");
                userInput.TempRating = tempRating;
                //passes my variables to my stored procedure
                return View("FilteredResults", connection.GetFilteredHolidays(holiday, continent, category, location, tempRating));
            }

            return View("InvalidTempRating");

        }

        public ActionResult SelectTempRating()
        {
            return View();
        }


        public ActionResult HolidayInput()
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