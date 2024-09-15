using Microsoft.AspNetCore.Mvc;
using pet2.Models;
using System.Diagnostics;

namespace pet2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
