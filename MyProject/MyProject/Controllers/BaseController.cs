using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyProject.Models;

namespace MyProject.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        private readonly IParametersService _parametersService;

        private readonly ISampleService _sampleService;

        private readonly IUnityService _unityService;

        private readonly IPlantService _plantService;

        public BaseController(IEquipmentService equipmentService,
            IParametersService parametersService, ISampleService sampleService, 
            IUnityService unityService, IPlantService plantService)
        {
            _equipmentService = equipmentService;
            _parametersService = parametersService;
            _sampleService = sampleService;
            _unityService = unityService;
            _plantService = plantService;
        }

        /// Метод необходим для выполнения базовой логики базового контроллера./>.
        /// <summary>
        public override void OnActionExecuting(ActionExecutingContext dbContext)
        {
            base.OnActionExecuting(dbContext);

            // Загружаем устройства и добавляем их в ViewBag
            var devices = _equipmentService.GetDeviceNamesAsync().Result;
            ViewBag.Devices = devices ?? new List<string>();
        }
    }
}
