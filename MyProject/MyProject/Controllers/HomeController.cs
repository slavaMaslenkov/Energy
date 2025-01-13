using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.Models;
using MyProject.Models.IService;
using System.Diagnostics;

namespace MyProject.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IEquipmentService equipmentService, 
            IParametersService parametersService, ISampleService sampleService, IUnityService unityService, 
            IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService, 
            IConnectionService connectionService, IUserService userService, IRoleService roleService) 
            : base(equipmentService, parametersService, sampleService, unityService, plantService, 
                  subsystemService, systemService, connectionService, userService, roleService) { }

        [Authorize]
        public IActionResult MainPage()
        {
            return View();
        }
    }
}
