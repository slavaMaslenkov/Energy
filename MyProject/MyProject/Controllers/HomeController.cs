using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IEquipmentService _equipmentService;

        public HomeController(IEquipmentService equipmentService) : base(equipmentService) { }

        public IActionResult MainPage()
        {
            return View();
        }
    }
}
