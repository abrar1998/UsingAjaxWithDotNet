using AjaxDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mono.TextTemplating;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using State = AjaxDotNet.Models.State;

namespace AjaxDotNet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }



        public JsonResult Cal(int x, int y)
        {
            int result = x + y;
            return Json(result);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            List<Country> countries = new List<Country>()
            {
                new Country { CountryId = 91, CountryName = "India" },
                new Country { CountryId = 92, CountryName = "Pakistan" },
                new Country { CountryId = 93, CountryName = "Bangladesh" },
            };

            List<State> states = new List<State>
            {

            };

           
            ViewBag.Countries = countries.ToList();
            return View();
        }

        [HttpPost]
        public string AddStudent(Student student)
        {
            string Location = ImageLocation(student.Photo);
            student.PhotoAddress = Location;
            var path = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            string filepath = Path.Combine(path, Location);
            using(FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                student.Photo.CopyTo(fs);
            }
            List<Student> stud = new List<Student>();
            stud.Add(student);

            return "success ";
        }

      

        public string ImageLocation(IFormFile photo)
        {
            string path = Guid.NewGuid().ToString() + "-"+ photo.FileName;
            Console.WriteLine("Pathhhhhhhhhhh isssss:"+path);
            return path;

        }


        [HttpPost]
        public JsonResult GetStates(int Cid)
        {
            List<State> states = new List<State>
            {
                new State{CountryId=91, StateId = 1, StateName="Jammu And Kashmir"},
                new State{CountryId=91, StateId = 2, StateName="Punjab"},
                new State{CountryId=91, StateId = 3, StateName="Haryana"},
                new State{CountryId=91, StateId = 4, StateName="Delhi"},
                new State{CountryId=92, StateId = 5, StateName=" Punjab"},
                new State{CountryId=92, StateId = 6, StateName="Islamabad"},
                new State{CountryId=92, StateId = 7, StateName="Gilgit"},
                new State{CountryId=92, StateId = 8, StateName="Kp"},
            };
            
        
            var state= states.Where(s=>s.CountryId==Cid).ToList();
            return Json(state);
        }

        public JsonResult GetCities(int Cid)
        {
            List<City> cities = new List<City>
            {
                new City{CityId=101, CityName="Srinagar", StateId=1},
                new City{CityId=102, CityName="Baramulla", StateId=1},
                new City{CityId=103, CityName="Jammu", StateId=1},
                new City{CityId=104, CityName="Kupwar", StateId=1},
                new City{CityId=105, CityName="Amritsar", StateId=2},
                new City{CityId=106, CityName="Chandigarh", StateId=2},
                new City{CityId=107, CityName="Bathinda", StateId=2},
                new City{CityId=108, CityName="Ludhaina", StateId=2},
            };

            return Json(cities.Where(c => c.StateId == Cid).ToList());
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
