using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, IPlantService plantService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService) { }

        public IActionResult MainPage()
        {
            return View();
        }
    }
}
