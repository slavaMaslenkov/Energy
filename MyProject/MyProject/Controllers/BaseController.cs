using DataAccess.Postgres.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpGet("/main")]
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var plants = await _plantService.GetAllAsync();
            // Преобразуем данные в список SelectListItem
            var plantList = plants.Select(plant => new SelectListItem
            {
                Value = plant.Id.ToString(),
                Text = plant.Name
            }).ToList();

            ViewBag.Plants = plantList;
            await next();
        }

        /// <summary>
        /// Метод для получения устройств, связанных со станцией.
        /// </summary>
        /// <param name="plantId">ID станции.</param>
        /// <returns>Список устройств.</returns>
        [HttpGet]
        public async Task<IActionResult> GetEquipmentByPlant(int plantId)
        {
            var equipment = await _equipmentService.GetEquipmentByPlant(plantId);

            var result = equipment.Select(e => new
            {
                e.Id,
                e.Name
            });

            return Json(result);
        }

        /// <summary>
        /// Метод для получения устройств, связанных со станцией.
        /// </summary>
        /// <param name="equipmentId">ID станции.</param>
        /// <returns>Список устройств.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSubsystemsByEquipment(int equipmentId)
        {
            var subsystems = await _systemService.GetAllByEquipment(equipmentId);

            var result = subsystems.Select(s => new
            {
                s.Subsystem.Id,
                s.Subsystem.Name
            });

            return Json(result);
        }
        /*
        /// <summary>
        /// Метод для получения подсистем, связанных с устройством.
        /// </summary>
        /// <param name="name">ID устройства.</param>
        /// <returns>Список подсистем в формате JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetSubsystemsByEquipment(string name)
        {
            var equipment = await _systemService.GetAllByEquipment(name);

            ViewBag.PlantList = new SelectList(equipment, "Id", "Name");
            return View();
        }*/
    }
}
