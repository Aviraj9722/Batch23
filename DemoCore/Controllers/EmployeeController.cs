using DemoCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.Controllers
{ 
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Index(Employee obj)
        {
            if (ModelState.IsValid ==false)
            {
                return BadRequest(ModelState);
            }
            ViewBag.msg = "Saved";

            return View();
        }
    }
}
