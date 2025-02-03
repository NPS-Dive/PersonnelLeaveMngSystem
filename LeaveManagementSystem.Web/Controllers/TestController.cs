using LeaveManagementSystem.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagementSystem.Web.Controllers
    {
    public class TestController : Controller
        {
        public IActionResult Index ()
            {
            var data = new TestViewModel
                {
                Name = "Amir"    ,
                DateOfBirth = new DateTime(1983,01,09)
                };
            return View(data);
            }
        }
    }
