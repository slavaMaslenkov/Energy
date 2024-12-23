using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyProject.Models;
using System.Drawing;
using System.Numerics;

namespace MyProject.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        private readonly IParametersService _parametersService;

        private readonly ISampleService _sampleService;

        private readonly IUnityService _unityService;

        private readonly IPlantService _plantService;

        private readonly ISubsystemService _subsystemService;

        private readonly ISystemService _systemService;

        public BaseController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, 
            IUnityService unityService, IPlantService plantService, ISubsystemService subsystemService, ISystemService systemService)
        {
            _equipmentService = equipmentService;
            _parametersService = parametersService;
            _sampleService = sampleService;
            _unityService = unityService;
            _plantService = plantService;
            _subsystemService = subsystemService;
            _systemService = systemService;
        }

        /// Метод необходим для выполнения базовой логики базового контроллера./>.
        /// <summary>
        public override void OnActionExecuting(ActionExecutingContext dbContext)
        {
            base.OnActionExecuting(dbContext);

            // Загружаем иерархию и передаем в ViewBag
            var hierarchy = _plantService.Hierarchy().Result;
            ViewBag.Plants = hierarchy ?? new List<dynamic>();
        }
    }
}
