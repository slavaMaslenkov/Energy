using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService) 
            : base(equipmentService, parametersService, sampleService) { }

        public IActionResult MainPage()
        {
            return View();
        }
    }
}
