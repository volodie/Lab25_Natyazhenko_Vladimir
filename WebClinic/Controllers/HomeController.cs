using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebClinic.Models;


namespace WebClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()

        {
            using (var context = new ClinicContext())
            {
                var doctors = context.Doctors.ToList();
                return View(doctors);
            }
            
        }

        public IActionResult Privacy()
        {
            using (var context = new ClinicContext())
            {
                var patients = context.Patients.ToList();
                return View(patients);
            }
           
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}