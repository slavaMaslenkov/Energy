using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService) 
            : base(equipmentService, parametersService, sampleService, unityService) { }

        public IActionResult MainPage()
        {
            return View();
        }
    }
}
