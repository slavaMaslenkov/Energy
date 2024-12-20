using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService, subsystemService, systemService) { }

        public IActionResult MainPage()
        {
            return View();
        }
    }
}
