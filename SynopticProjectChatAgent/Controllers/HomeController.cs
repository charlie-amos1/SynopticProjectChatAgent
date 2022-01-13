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
        //private string dbConnectionString = "Data Source=.;Initial Catalog=ProjectCDatabase;Integrated Security=True";
        private DataConnection connection = new DataConnection();
        private UiHolidayModel model = new UiHolidayModel();
        private FilterOptions filter = new FilterOptions();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ViewAll()
        {
            return View(connection.GetAllHolidays(holiday));
        }

        public bool ValidateInput(string input, List<string> categoryFilter, string viewName)
        {

            if (input!= null)
            {
                if (categoryFilter.Contains(input))
                {
                    return true;
                }

            }
            return false;
        }

        [HttpPost]
        public ActionResult SelectContinent(string continent)
        {
            if (ValidateInput(continent,filter.ContinentsList,"SelectCategory")==true)
            {
                userInput.Continent = continent;
                HttpContext.Session.SetString("Continent", JsonConvert.SerializeObject(userInput.Continent));
                return View("SelectCategory");

            }
            return View("InvalidContinent");

        }


        [HttpPost] 
        public ActionResult SelectCategory(string category) 
        {
            if (ValidateInput(category, filter.CategoryList, "SelectCategory") == true)
            {
                userInput.Category = category;
                HttpContext.Session.SetString("Category", JsonConvert.SerializeObject(userInput.Category));
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
            return View("");
        }

        [HttpPost]
        public ActionResult SelectLocation(string location)
        {
            if (ValidateInput(location, filter.LocationList, "SelectLocation") == true)
            {
                userInput.Location = location;
                HttpContext.Session.SetString("Location", JsonConvert.SerializeObject(userInput.Location));
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
            var continent = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Continent"));
            var category = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Category"));
            var location = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Location"));
            
            if (ValidateInput(tempRating, filter.TempRatingList, "SelectTempRating") == true)
            {

                userInput.TempRating = tempRating;
                HttpContext.Session.SetString("TempRating", JsonConvert.SerializeObject(tempRating));


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