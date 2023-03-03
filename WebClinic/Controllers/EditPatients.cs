using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebClinic.Models;


namespace WebClinic.Controllers
{
    public class EditPatients : Controller
    {
        
        public IActionResult ShowP()
        {
            return View();
        }
        public IActionResult PatientShow(int id)
        {
            using (var context = new ClinicContext())
            {
                var patients = context.Patients.Where(x => x.PatientId == id).ToList();
                return View(patients);
            }

        }
        //public IActionResult Index()
        //{
        //    ViewData["Result"] = "Hello! ";
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}