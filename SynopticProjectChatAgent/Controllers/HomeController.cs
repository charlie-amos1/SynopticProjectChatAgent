using Dapper;
using Microsoft.AspNetCore.Mvc;
using SynopticProjectChatAgent.Data;
using SynopticProjectChatAgent.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;
using Newtonsoft.Json;
using SynopticProjectChatAgent.FilterModels;
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
        private UiHolidayFilters holidayFilters= new UiHolidayFilters();
 
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;
        private string _location;
        private string _tempating;

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
            HttpContext.Session.SetString("Continent", JsonConvert.SerializeObject(userInput.Continent));
            return View("SelectCategory");

        }

        //}


        [HttpPost] 
        public ActionResult SelectCategory(string category) 
        {
            userInput.Category= category;
            HttpContext.Session.SetString("Category", JsonConvert.SerializeObject(userInput.Category));
            return View("SelectLocation");
        }

        public ActionResult SelectContinent() 
        {
            return View();
        }

    [HttpPost]
        public ActionResult SelectLocation(string location)
        {
            userInput.Location= location;
            HttpContext.Session.SetString("Location", JsonConvert.SerializeObject(userInput.Location));
            return View("SelectTempRating");
        }

        [HttpPost]
        public ActionResult SelectTempRating(string tempRating)
        {
            userInput.TempRating = tempRating;
            HttpContext.Session.SetString("TempRating", JsonConvert.SerializeObject(tempRating));

            //var continent = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Continent"));
            //var category = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Category"));
            //var location = JsonConvert.DeserializeObject<string>(HttpContext.Session.GetString("Location"));

            return View("FilteredResults", connection.GetFilteredHolidays(holiday, "active", "Sea", "Mild"));
        }

        public ActionResult SelectTempRating()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult FilteredResults() 
        //{


        //}

        public ActionResult HolidayInput() 
        {
            return View();
        }

        public ActionResult EnterChatBot() 
        {
            return View("SelectCategory");
        }

        public IActionResult Index()
        {
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