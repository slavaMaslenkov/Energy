using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
